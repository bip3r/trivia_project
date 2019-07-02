#include "Validator.h"

Validator::Validator()
{
}


Validator::~Validator()
{
}

//This function checks if there is some char in a given string, that its ascii is between the 2 given ascii numbers.
//Input: string, 2 ascii numbers.
//Output: true if there is a char. Else - false.
bool isCharExist(std::string str, int asc1, int asc2)
{
	bool exist = false;
	for (int i = 0; i < str.length(); i++)
	{
		if (str[i] >= asc1 && str[i] <= asc2)
		{
			exist = true;
			break;
		}
	}
	return exist;
}

bool Validator::isUsernameValid(std::string username)
{
	bool valid = true;
	if (username.length() == 0)
		valid = false;
	else if (username[0] < 65 || (username[0] > 90 && username[0] < 97) || username[0] > 122)
		valid = false;
	else if (isCharExist(username, 32, 32))
		valid = false;
	return valid;
}

bool Validator::isPasswordValid(std::string password)
{
	bool valid = true;
	if (password.length() < 4)
		valid = false;
	else if (!isCharExist(password, 48, 57))
		valid = false;
	else if (!isCharExist(password, 65, 90))
		valid = false;
	else if (!isCharExist(password, 97, 122))
		valid = false;
	else if (isCharExist(password, 32, 32))
		valid = false;
	return valid;
}