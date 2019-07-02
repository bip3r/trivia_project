#include "TriviaServer.h"

std::condition_variable cond;
std::mutex base_lock_que;
std::unique_lock<std::mutex> mlock(base_lock_que);
int TriviaServer::_roomIdsequence;

TriviaServer::TriviaServer()
{
	//activate DataBase ctor
	TriviaServer::_roomIdsequence = 0;
}

void TriviaServer::server()
{
	std::thread tr(&TriviaServer::bindAndListen, this);
	tr.detach();
	handleRecievedMessage();
}


void TriviaServer::bindAndListen()
{

	struct sockaddr_in sa = { 0 };
	int port = 8820;
	sa.sin_port = htons(port);
	sa.sin_family = AF_INET;
	sa.sin_addr.s_addr = INADDR_ANY;
	WSAInitializer wsaInit; // as i found out, this shit is super important!
	_serverSocket = ::socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (_serverSocket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");

	if (::bind(_serverSocket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - bind");

	if (::listen(_serverSocket, SOMAXCONN) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - listen");

	std::cout << "Listening on port " << port << std::endl;

	while (true)
	{
		std::cout << "Waiting for client connection request" << std::endl;
		accept();
	}
}


void  TriviaServer::clientHandler(SOCKET client_socket)
{
	while (true)
	{
		int msgCode;
		try
		{
			msgCode = Helper::getMessageTypeCode(client_socket);
			std::cout << "------------------------------------" << std::endl;
			std::cout << "msgcode :" << msgCode << std::endl;
			buildRecieveMessage(client_socket, msgCode);
		}
		catch (std::exception& e)
		{
			buildRecieveMessage(client_socket, 299);
			break;
		}

	}
}

void TriviaServer::buildRecieveMessage(SOCKET client_socket, int msgCode)
{
	std::vector<std::string> msgArgs;
	RecievedMessage* msg = nullptr;
	if (msgCode == SIGN_IN)
	{
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket,Helper::getIntPartFromSocket(client_socket, 2)));
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, Helper::getIntPartFromSocket(client_socket, 2)));
		
		msg = new RecievedMessage(client_socket, msgCode, msgArgs);
	}
	else if (msgCode == SIGN_OUT)
	{
		msg = new RecievedMessage(client_socket, msgCode);
	}
	else if (msgCode == SIGN_UP)
	{
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, Helper::getIntPartFromSocket(client_socket, 2)));
		//this->_connectedUsers[client_socket] = new User(msgArgs.front(), client_socket);
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, Helper::getIntPartFromSocket(client_socket, 2)));
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, Helper::getIntPartFromSocket(client_socket, 2)));

		for (size_t i = 0; i < msgArgs.size(); i++)
		{
			std::cout << msgArgs[i] << std::endl;
		}
		msg = new RecievedMessage(client_socket, msgCode, msgArgs);
	}

	else if (msgCode == ROOM_LIST_REQUEST)
	{
		msg = new RecievedMessage(client_socket, msgCode);
	}

	else if (msgCode == ROOM_REQUEST_USERS)
	{
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, 4));
		msg = new RecievedMessage(client_socket, msgCode, msgArgs);
	}
	else if (msgCode == JOIN_ROOM)
	{
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, 4));
		msg = new RecievedMessage(client_socket, msgCode, msgArgs);
	}
	else if (msgCode == CREATE_ROOM)
	{
		msgArgs.push_back(Helper::getStringPartFromSocket(
			client_socket, Helper::getIntPartFromSocket(client_socket, 2)));
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, 1));
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, 2));
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, 2));
		msg = new RecievedMessage(client_socket, msgCode, msgArgs);
	}
	else if (msgCode == CLOSE_ROOM)
	{
		msg = new RecievedMessage(client_socket, msgCode);
	}
	else if (msgCode == LEAVE_ROOM)
	{
		msg = new RecievedMessage(client_socket, msgCode);
	}
	else if (msgCode == START_GAME)
	{
		msg = new RecievedMessage(client_socket, msgCode);
	}
	else if (msgCode == ANSWER)
	{
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, 1));
		msgArgs.push_back(Helper::getStringPartFromSocket(client_socket, 2));
		msg = new RecievedMessage(client_socket, msgCode, msgArgs);
	}
	else if (msgCode == LEAVE_GAME)
	{
		msg = new RecievedMessage(client_socket, msgCode);
	}
	else if (msgCode == GET_SCORE)
	{
		msg = new RecievedMessage(client_socket, msgCode);
	}
	else if (msgCode == GET_PERSONAL_STATS)
	{
		msg = new RecievedMessage(client_socket, msgCode);
	}
	else if (msgCode == EXIT_APPLICATION)
	{
		msg = new RecievedMessage(client_socket, msgCode);
	}
	addRecievedMessage(msg);
}

void TriviaServer::handleRecievedMessage()
{
	while (true)
	{

		RecievedMessage* tmsg;
		if (this->_queRcvMessages.empty())
		{
			cond.wait(mlock);
		}
		tmsg = this->_queRcvMessages.front();
		this->_queRcvMessages.pop();
		std::cout <<"socket :"<< tmsg->getSock() << std::endl;
		if (this->_connectedUsers.find(tmsg->getSock()) == this->_connectedUsers.end())
		{
			tmsg->setUser(nullptr);
		}
		else
		{
			tmsg->setUser(this->_connectedUsers.find(tmsg->getSock())->second);
		}
		int msgCode = tmsg->getMessageCode();

		if (msgCode == SIGN_IN)
		{
			handleSignin(tmsg);
		}

		else if (msgCode == SIGN_UP)
		{
			handleSignup(tmsg);
		}
		else if (msgCode == SIGN_OUT)
		{
			handleSignout(tmsg);
		}
		else if (msgCode == ROOM_LIST_REQUEST)
		{
			handleGetRooms(tmsg);
		}
		else if (msgCode == ROOM_REQUEST_USERS)
		{
			handleGetUsersInRoom(tmsg);
		}
		else if (msgCode == JOIN_ROOM)
		{
			handleJoinRoom(tmsg);
		}
		else if (msgCode == CREATE_ROOM)
		{
			handleCreateRoom(tmsg);
		}
		else if (msgCode == LEAVE_ROOM)
		{
			handleLeaveRoom(tmsg);
		}
		else if (msgCode == CLOSE_ROOM)
		{
			handleCloseRoom(tmsg);
		}
		else if (msgCode == START_GAME)
		{
			handleStartGame(tmsg);
		}
		else if (msgCode == ANSWER)
		{
			handlePlayerAnswer(tmsg);
		}
		else if (msgCode == LEAVE_GAME)
		{
			handleLeaveGame(tmsg);
		}
		else if (msgCode == GET_SCORE)
		{
			handleGetBestscores(tmsg);
		}
		else if (msgCode == GET_PERSONAL_STATS)
		{
			handleGetPersonalStatus(tmsg);
		}
		else if (msgCode == EXIT_APPLICATION)
		{
			safeDeleteUser(tmsg);
		}
		delete tmsg;
	}
}


void TriviaServer::handleSignin(RecievedMessage* msg)
{
	std::string pass = msg->getValues().back();
	std::string uname = msg->getValues().front();
	bool connected = false, legal = false;
	for (auto it = this->_connectedUsers.begin(); it != this->_connectedUsers.end(); it++)
	{
		if (it->second->getUsername() == uname)
		{
			connected = true;
			break;
		}
	}
	if (connected)
	{
		std::cout << "sending: " << SIGN_IN_CONNECTED << std::endl;
		Helper::sendData(msg->getSock(), std::to_string(SIGN_IN_CONNECTED));
	}


	else if (this->_db.isUserExists(uname))
	{
		if (this->_db.isUserAndPassMatch(uname,pass))
		{
			legal = true;
			std::cout << "sending: " << SIGN_IN_SUCCESS << std::endl;
			Helper::sendData(msg->getSock(), std::to_string(SIGN_IN_SUCCESS));
			this->_connectedUsers[msg->getSock()] = new User(uname, msg->getSock());
		}		
	}

	//else if (this->_db.isUserExists(uname))
	//{
	//	if (this->_db.isUserAndPassMatch(uname,pass))
	//	{
	//		legal = true;
	//		std::cout << "sending: " << SIGN_IN_SUCCESS << std::endl;
	//		Helper::sendData(msg->getSock(), std::to_string(SIGN_IN_SUCCESS));
	//		this->_connectedUsers[msg->getSock()] = new User(uname, msg->getSock());
	//	}
	//}
	if(!legal)
	{
		std::cout << "sending: " << SIGN_IN_WRONG_DETAILS << std::endl;
		Helper::sendData(msg->getSock(), std::to_string(SIGN_IN_WRONG_DETAILS));
	}
}

void TriviaServer::handleSignup(RecievedMessage* msg)
{
	std::vector<std::string> tvalues = msg->getValues();
	std::string email = tvalues.back();
	tvalues.pop_back();
	std::string uname = tvalues.front();
	std::string pass = tvalues.back();
	std::cout << "pass: " << pass << " uname: " << uname << " email: " << email << std::endl;
	if (this->_availableUsers.find(uname) != this->_availableUsers.end())
	{
		std::cout << "sending: " << SIGN_UP_EXISTS << std::endl;
		Helper::sendData(msg->getSock(), std::to_string(SIGN_UP_EXISTS));
	}
	else if (!Validator::isPasswordValid(pass))
	{
		std::cout << "sending: " << SIGN_UP_PASS_ILLEGAL << std::endl;
		Helper::sendData(msg->getSock(), std::to_string(SIGN_UP_PASS_ILLEGAL));
	}
	else if (!Validator::isUsernameValid(uname))
	{
		std::cout << "sending: " << SIGN_UP_USER_ILLEGAL << std::endl;
		Helper::sendData(msg->getSock(), std::to_string(SIGN_UP_USER_ILLEGAL));
	}
	else
	{
		try
		{
			this->_db.addNewUser(uname, pass, email);
			this->_availableUsers[uname] = pass;
			std::cout << "sending: " << SIGN_UP_SUCCESS << std::endl;
			Helper::sendData(msg->getSock(), std::to_string(SIGN_UP_SUCCESS));
		}
		catch (const std::exception&)
		{
			std::cout << "sending: " << SIGN_UP_OTHER_ERROR << std::endl;
			Helper::sendData(msg->getSock(), std::to_string(SIGN_UP_OTHER_ERROR));
		}
	}

}

void TriviaServer::accept()
{
	SOCKET client_socket = ::accept(_serverSocket, NULL, NULL);
	if (client_socket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__);

	std::cout << "Client accepted. Server and client can speak" << std::endl;
	std::thread t(&TriviaServer::clientHandler, this, client_socket);
	t.detach();
}

TriviaServer::~TriviaServer()
{
	std::map<SOCKET, User*>::iterator it = this->_connectedUsers.begin();
	for ( it = this->_connectedUsers.begin(); it != this->_connectedUsers.end(); it++)
	{
		delete it->second;
	}

	for (auto it2 = this->_roomsList.begin(); it2 != this->_roomsList.end(); it2++)
	{
		delete it2->second;
	}

	closesocket(_serverSocket);
	//close socket
}


void TriviaServer::addRecievedMessage(RecievedMessage* msg)
{
	this->_queRcvMessages.push(msg);
	cond.notify_all();
}


void TriviaServer::handleGetRooms(RecievedMessage* msg)
{
	std::string roomListMsg = std::to_string(ROOM_LIST_RESPONSE);
	int size = this->_roomsList.size();
	char c[5] = { 0 };
	for (int i = 3; i  > -1; i--)
	{
		c[i] = char((size % 10) + 48);
		size = size / 10;
	}
	roomListMsg += c;
	auto it = this->_roomsList.begin();
	while (it != this->_roomsList.end())
	{
		int id = it->first;
		for (int i = 3; i > -1; i--)
		{
			c[i] = char((id % 10) + 48);
			id = id / 10;
		}
		roomListMsg += c;
		if (it->second->getName().size() < 10)
		{
			roomListMsg += '0';
		}
		roomListMsg += std::to_string(it->second->getName().size());
		roomListMsg += it->second->getName();
		it++;
	}
	std::cout << roomListMsg << std::endl;
	Helper::sendData(msg->getSock(), roomListMsg);
}

void TriviaServer::handleGetUsersInRoom(RecievedMessage* msg)
{
	std::string res = std::to_string(PLAYERS_IN_ROOM);
	int rid = atoi(msg->getValues().at(0).c_str());
	Room* t = this->_roomsList[rid];
	Helper::sendData(msg->getSock(),t->getUsersListMessage());
}

bool TriviaServer::handleJoinRoom(RecievedMessage* msg)
{

	Room* t;
	int rid;
	//std::cout << "msg code : " << msg->getMessageCode() << " ";
	if (msg->getUser() == nullptr)
	{
		std::cout << "user null";
		return false;
	}
	try
	{
		std::string srid = msg->getValues()[0];
		rid = atoi(srid.c_str());
		t = getRoomById(rid);
	}
	catch (const std::exception&)
	{
		std::cout << "failed reciving data from packet." << std::endl;
		Helper::sendData(msg->getSock(), std::to_string(JOIN_ROOM_OTHER));
		return false;
	}
	return msg->getUser()->joinRoom(t);
}
Room* TriviaServer::getRoomById(int RoomId)
{
	return this->_roomsList[RoomId] != nullptr ? this->_roomsList[RoomId] : nullptr;
}

bool TriviaServer::handleCreateRoom(RecievedMessage* msg)
{
	User* tu = msg->getUser();
	std::cout << "msg code : " << msg->getMessageCode() << " ";
	if (tu == nullptr)
	{
		std::cout << "user null";
		return false;
	}

	std::vector<std::string> values = msg->getValues();
	TriviaServer::_roomIdsequence++;
	if (tu->createRoom(TriviaServer::_roomIdsequence, values[0], atoi(values[1].c_str())
		, atoi(values[2].c_str()), atoi(values[3].c_str())))
	{
		this->_roomsList[TriviaServer::_roomIdsequence] = tu->getRoom();
		Helper::sendData(msg->getSock(), std::to_string(CREATE_ROOM_SUCCESS));
		std::cout << "Success !" <<std::endl;
		return true;
	}
	else
	{
		std::cout << "Failure !" << std::endl;
		return false;
	}
}

bool TriviaServer::handleCloseRoom(RecievedMessage* msg)
{
	User* usr = msg->getUser();
	if (usr == nullptr)
	{
		return false;
	}
	int id;
	if ((id = usr->closeRoom()) == -1)
	{
		return false;
	}

	this->_roomsList.erase(id);
	return true;
}

bool TriviaServer::handleLeaveRoom(RecievedMessage* msg)
{
	User* usr = msg->getUser();
	if (usr == nullptr)
	{
		return false;
	}

	usr->leaveRoom();
	return true;
}

void TriviaServer::handleSignout(RecievedMessage* msg)
{
	User* u = msg->getUser();
	if (u == nullptr)
	{
		return;
	}
	
	handleCloseRoom(msg);
	handleLeaveRoom(msg);
	this->_connectedUsers.erase(msg->getSock());
}

void TriviaServer::handleStartGame(RecievedMessage* msg)
{
	User* u = msg->getUser();
	Game* g = nullptr;
	try
	{
		std::vector<User*> vu = std::vector<User*>(u->getRoom()->getUsers());
		auto it = vu.begin();

		g = new Game(this->_db, u->getRoom()->getQuestionsNo(), vu);
		u->setGame(g);
		this->_roomsList.erase(u->getRoom()->getId());
		while (it != vu.end())
		{
			(*it)->clearRoom();
			it++;
		}
		g->sendFirstQuestion();
	}
	catch (const std::exception& e)
	{
		std::cout << e.what() << std::endl;
		Helper::sendData(u->getSocket(), "1180");
	}
}

void TriviaServer::handlePlayerAnswer(RecievedMessage* msg)
{
	User* u = msg->getUser();
	Game* g = u->getGame();
	if (g!=nullptr)
	{
		if (!g->handleAnswerFromUser(u, std::stoi(msg->getValues()[0]), std::stoi(msg->getValues()[1])))
		{
			u->clearGame();
		}
	}
}

void TriviaServer::handleLeaveGame(RecievedMessage* msg)
{
	User* u = msg->getUser();
	if (u->leaveGame())
	{
		delete u->getGame();
		u->clearGame();
	}
}

void TriviaServer::handleGetBestscores(RecievedMessage* msg)
{
	std::vector<std::string> best_scores = this->_db.getBestScores();

	while (best_scores.size() < 6)
	{
		best_scores.push_back("");
	}
	std::stringstream ssmsg;
	ssmsg << std::to_string(SCORES);
	auto it = best_scores.begin();
	while (it != best_scores.end())
	{
		if (*it == "")
		{
			ssmsg << "00";
		}
		else
		{
			ssmsg << std::setfill('0') << std::setw(2) << (*it).size();
			ssmsg << *it;
		}
		it++; 
		if (*it == "")
		{
			ssmsg << "000000";
		}
		else
		{
			ssmsg << std::setfill('0') << std::setw(6) << *it;
		}
		it++;
	}
	std::cout << ssmsg.str() << std::endl;
	Helper::sendData(msg->getSock(), ssmsg.str());
}


void TriviaServer::handleGetPersonalStatus(RecievedMessage* msg)
{
	std::vector<std::string> personal_info = this->_db.getPersonalStatus(msg->getUser()->getUsername());
	std::stringstream smsg;
	auto it = personal_info.begin();
	smsg << std::to_string(PERSONAL_STATS);
	smsg << std::setfill('0') << std::setw(4) << personal_info[0];
	smsg << std::setfill('0') << std::setw(6) << personal_info[1];
	smsg << std::setfill('0') << std::setw(6) << personal_info[2];
	std::string inte = personal_info[3].substr(0,personal_info[3].find('.'));
	std::string real = personal_info[3].substr(personal_info[3].find('.')+1, personal_info[3].find('.')+1);
	smsg << std::setfill('0') << std::setw(2) << inte;
	smsg << std::setfill('0') << std::setw(2) << real;
	std::cout << smsg.str() << std::endl;
	Helper::sendData(msg->getSock(), smsg.str());
}

void TriviaServer::safeDeleteUser(RecievedMessage* msg)
{
	handleSignout(msg);
	closesocket(msg->getSock());
}




