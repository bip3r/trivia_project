#pragma once
#include "RecievedMessage.h"
#include <map>
#include <queue>
#include <Windows.h>
#include "WSAInitializer.h"
#include <thread>
#include "Protocol.h"
#include <mutex>
#include "Validator.h"
#include "DataBase.h"
class TriviaServer
{
public:
	TriviaServer();
	~TriviaServer();
	void server();


private: 
	std::map<SOCKET, User*> _connectedUsers;
	std::map<int, Room*> _roomsList;
	std::queue<RecievedMessage*> _queRcvMessages;
	static int _roomIdsequence;
	std::map<std::	string, std::string> _availableUsers;
	SOCKET _serverSocket;
	DataBase _db;

	void bindAndListen();
	void clientHandler(SOCKET client_socket);
	void buildRecieveMessage(SOCKET client_socket,int msgCode);
	void handleSignin(RecievedMessage* msg);
	void handleSignup(RecievedMessage* msg);
	void handleRecievedMessage();
	void addRecievedMessage(RecievedMessage* msg);
	void accept();
	void handleGetRooms(RecievedMessage* msg);
	bool handleJoinRoom(RecievedMessage* msg);
	bool handleCloseRoom(RecievedMessage* msg);
	bool handleCreateRoom(RecievedMessage* msg);
	bool handleLeaveRoom(RecievedMessage* msg);
	void handlePlayerAnswer(RecievedMessage* msg);
	void handleStartGame(RecievedMessage* msg);
	void handleLeaveGame(RecievedMessage* msg);
	void handleGetUsersInRoom(RecievedMessage* msg);
	void handleSignout(RecievedMessage* msg);
	void handleGetBestscores(RecievedMessage* msg);
	void handleGetPersonalStatus(RecievedMessage* msg);
	void safeDeleteUser(RecievedMessage* msg);
	Room* getRoomById(int roomId);
};

