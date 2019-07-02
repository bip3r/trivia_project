#pragma once
#include "User.h"
#include <vector>
class RecievedMessage
{
public:
	RecievedMessage(SOCKET sock, int messageCode);
	RecievedMessage(SOCKET sock, int messageCode, std::vector<std::string> values);
	SOCKET getSock();
	User* getUser();
	void setUser(User* user);
	int getMessageCode();
	std::vector<std::string> getValues();
	~RecievedMessage();

private:
	SOCKET _sock;
	User* _user;
	int _messageCode;
	std::vector<std::string> _values;
};

