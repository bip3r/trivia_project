#include "Room.h"
int findIndex(std::vector<User*> users, User* user);

Room::Room(int id, User* admin, std::string name, int maxUsers, int questionsNo, int questionTime)
{
	this->_id = id;
	this->_admin = admin;
	this->_name = name;
	this->_maxUsers = maxUsers;
	this->_questionsNo = questionsNo;
	this->_questionTime = questionTime;
	this->_users.push_back(admin);
}

Room::~Room()
{
}

int Room::getQuestionsNo()
{
	return this->_questionsNo;
}

int Room::getId()
{
	return this->_id;
}

std::string Room::getName()
{
	return this->_name;
}

std::vector<User*> Room::getUsers()
{
	return this->_users;
}

std::string Room::getUsersAsString(std::vector<User*> users, User* excludeUser)
{
	std::vector<User*>::iterator it;
	std::string shitstorm;
	for (it = users.begin(); it != users.end(); it++)
	{
		if (*it != excludeUser)
			shitstorm += (*it)->getUsername();
	}
	return shitstorm;
}

std::string Room::getUsersListMessage()
{
	std::stringstream ss;
	ss << this->_users.size();
	std::string msg = "108" + ss.str();
	std::vector<User*>::iterator it;
	for (it = this->_users.begin(); it != this->_users.end(); it++)
	{
		int size = (*it)->getUsername().length();
		if (size < 10)
		{
			msg += '0';
		}
		msg += std::to_string(size) +(*it)->getUsername();
	}
	return msg;
}

void Room::sendMessage(User* excludeUser, std::string message)
{
	std::vector<User*>::iterator it;
	for (it = this->_users.begin(); it != this->_users.end(); it++)
	{
		if (*it != excludeUser)
		{
			(*it)->send(message);
		}
	}
}

void Room::sendMessage(std::string message)
{
	this->sendMessage(NULL, message);
}

bool Room::joinRoom(User* user)
{
	bool is_user_can_join = true;
	std::string pkt = "1100";
	if (this->_users.size() == this->_maxUsers)
	{
		pkt[3] = '1';
		is_user_can_join = false;
	}
		
	else
	{
		this->_users.push_back(user);
		if (this->_questionsNo < 10)
		{
			pkt += '0';
		}
		pkt += std::to_string(this->_questionsNo);
		if (this->_questionTime < 10)
		{
			pkt += '0';
		}
		pkt += std::to_string(this->_questionTime);
	}
	Helper::sendData(user->getSocket(), pkt);
	if (pkt[3] == '0')
		this->sendMessage(this->getUsersListMessage());
	return is_user_can_join;
}

void Room::leaveRoom(User* user)
{
	unsigned int index = findIndex(this->_users, user);
	if (index != this->_users.size())
	{
		this->_users.erase(this->_users.begin() + index);
		send(user->getSocket(), "1120", 4, 0);
		this->sendMessage(this->getUsersListMessage());
	}
		
}

int Room::closeRoom(User* user)
{
	int id = -1;
	if (this->_admin == user)
	{
		id = this->_id;
		this->sendMessage("116");
		std::vector<User*>::iterator it;
		for (it = this->_users.begin(); it != this->_users.end(); it++)
		{
			(*it)->clearRoom();
		}
	}
	return id;
}

int findIndex(std::vector<User*> users, User* user)
{
	unsigned int i = 0;
	for (i = 0; i < users.size(); i++)
	{
		if (users[i] == user)
			break;
	}
	return i;
}