#pragma once
#include <string>
class Validator
{
public:
	Validator();
	~Validator();
	static bool isUsernameValid(std::string);
	static bool isPasswordValid(std::string);
};

