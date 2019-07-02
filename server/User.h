#pragma once
#include <WinSock2.h>
#include <string>
#include "Room.h"
#include "Game.h"
#include "Helper.h"

class Room;
class Game;

class User
{
private:
	std::string _username;
	Room* _currRoom;
	Game* _currGame;
	SOCKET _sock;
public:
	User(std::string, SOCKET);
	~User();
	void send(std::string);
	std::string getUsername();
	SOCKET getSocket();
	Room* getRoom();
	Game* getGame();
	void setGame(Game*);
	void clearRoom();
	void clearGame();
	bool createRoom(int, std::string, int, int, int);
	bool joinRoom(Room*);
	void leaveRoom();
	int closeRoom();
	bool leaveGame();
};

