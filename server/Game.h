#pragma once
#include "DataBase.h"
#include "Question.h"
#include "Protocol.h"
#include "User.h"
#include <map>
#include <vector>
#include <iomanip>

class User;

class Game
{
private: 
	std::map<std::string, int> _results;
	int _curretTurnAnswers;
	std::vector<Question*> _questions;
	std::vector<User*> _players;
	DataBase& _db;
	int _currQuestionIndex;
	int _id;

	int _questions_no;
	bool insertGameToDB();
	void initQuestionsFromDB();
	void sendQuestionsToAllUsers();

public:
	Game(DataBase& db,int questionNo, const std::vector<User*> players);
	~Game();
	void sendFirstQuestion();
	void handleFinishGame();
	bool handleNextTurn();
	bool handleAnswerFromUser(User* user, int answerNo, int time);
	bool leaveGame(User* currUser);
	int getID();
};

