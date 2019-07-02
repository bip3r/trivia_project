#pragma once
#include <iostream>
#include <string>
#include <vector>
#include "User.h"
#include <sstream>

class User;

class Room
{
private:
	std::vector<User*> _users;
	User* _admin;
	int _maxUsers;
	int _questionTime;
	int _questionsNo;
	std::string _name;
	int _id;

	std::string getUsersAsString(std::vector<User*>, User*);
	void sendMessage(std::string);
	void sendMessage(User*, std::string);

public:
	Room(int, User*, std::string, int, int, int);
	~Room();
	bool joinRoom(User*);
	void leaveRoom(User*);
	int closeRoom(User*);
	std::vector<User*> getUsers();
	std::string getUsersListMessage();
	int getQuestionsNo();
	int getId();
	std::string getName();
};