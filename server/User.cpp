#include "User.h"

User::User(std::string username, SOCKET sock)
{
	this->_username = username;
	this->_sock = sock;
	this->_currRoom = nullptr;
	this->_currGame = nullptr;
}

User::~User()
{
}

std::string User::getUsername()
{
	return this->_username;
}

SOCKET User::getSocket()
{
	return this->_sock;
}

Room* User::getRoom()
{
	return this->_currRoom;
}

Game* User::getGame()
{
	return this->_currGame;
}

void User::send(std::string message)
{
	Helper::sendData(this->_sock, message);
}

void User::setGame(Game* game)
{
	this->_currGame = game;
}

void User::clearGame()
{
	this->_currGame = nullptr;
}

bool User::createRoom(int roomId, std::string roomName, int maxUsers, int questionsNo, int questionTime)
{
	bool can_create = true;
	std::string sendMessage = "1140";
	if (this->_currRoom != nullptr)
	{
		sendMessage[3] = '1';
		can_create = false;
	}
	else
	{
		this->_currRoom = new Room(roomId, this, roomName, maxUsers, questionsNo, questionTime);
	}
	::send(this->_sock, sendMessage.c_str(), 4, 0);
	return can_create;
}

bool User::joinRoom(Room* room)
{
	bool can_join = true;
	if (this->_currRoom != nullptr)
		can_join = false;
	else
	{
		room->joinRoom(this);
		this->_currRoom = room;
	}
	return can_join;
}

void User::leaveRoom()
{
	if (this->_currRoom != nullptr)
	{
		this->_currRoom->leaveRoom(this);
		this->_currRoom = nullptr;
	}
}

int User::closeRoom()
{
	int id = -1;
	if (this->_currRoom != nullptr)
	{
		id = this->_currRoom->closeRoom(this);
	}
    this->_currRoom = nullptr;
	return id;
}

bool User::leaveGame()
{
	bool game_still_active = true;
	if (this->_currGame == nullptr)
		game_still_active = false;
	else
	{
		this->_currGame->leaveGame(this);
		this->_currGame = nullptr;
	}
	return game_still_active;
}

void User::clearRoom()
{
	this->_currRoom = nullptr;
}