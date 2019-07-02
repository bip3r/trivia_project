#include "RecievedMessage.h"



RecievedMessage::RecievedMessage(SOCKET sock, int messageCode)
{
	this->_sock = sock;
	this->_messageCode = messageCode;
	this->_values = std::vector<std::string>();
	this->_user = nullptr;
}

RecievedMessage::RecievedMessage(SOCKET sock, int messageCode, std::vector<std::string> values)
{
	this->_sock = sock;
	this->_messageCode = messageCode;
	this->_values = values;
	this->_user = nullptr;
}

SOCKET RecievedMessage::getSock()
{
	return this->_sock;
}

User* RecievedMessage::getUser()
{
	return this->_user;
}

void RecievedMessage::setUser(User* user)
{
	this->_user = user;
}

std::vector<std::string> RecievedMessage::getValues()
{
	return this->_values;
}

int RecievedMessage::getMessageCode()
{
	return this->_messageCode;
}

RecievedMessage::~RecievedMessage()
{
}
