#pragma once
#include <vector>
#include "sqlite3.h"
#include "Question.h"
class DataBase
{
private:
	int static callbackCount(void*, int, char**, char**);
	int static callbackQuestions(void*, int, char**, char**);
	int static callbackBestScored(void*, int, char**, char**);
	int static callbackPersonalStatus(void*, int, char**, char**);
public:
	DataBase();
	~DataBase();
	bool isUserExists(std::string);
	bool addNewUser(std::string, std::string, std::string);
	bool isUserAndPassMatch(std::string, std::string);
	std::vector<Question*> initQuestions(int);
	std::vector<std::string> getBestScores();
	std::vector<std::string> getPersonalStatus(std::string);
	int insertNewGame();
	bool updateGameStatus(int);
	bool addAnswerToPlayer(int, std::string, int, std::string, bool, int);
};

