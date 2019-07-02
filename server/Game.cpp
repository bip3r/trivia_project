#include "Game.h"



Game::Game(DataBase& db, int questionsNo, const std::vector<User*> players) :_db(db)
{
	if (!insertGameToDB())
	{
		throw std::exception("error init db");
	}
	this->_questions_no = questionsNo;
	initQuestionsFromDB();
	for (auto it = players.begin(); it != players.end(); it++)
	{
		this->_results[(*it)->getUsername()] = 0;
		(*it)->setGame(this);
	}
	this->_players = players;
}

void Game::sendQuestionsToAllUsers()
{
	std::stringstream msg;
	msg <<std::to_string(SEND_QUESTION);
	msg << std::setfill('0') << std::setw(3) << this->_questions[this->_currQuestionIndex]->getQuestion().size();
	msg << this->_questions[this->_currQuestionIndex]->getQuestion();
	this->_curretTurnAnswers = 0;
	std::string* anss = this->_questions[this->_currQuestionIndex]->getAnswers();
	for (int i = 0; i < 4; i++)
	{
		msg << std::setfill('0') << std::setw(3) << anss[i].size();
		msg << anss[i];
	}
	std::cout << msg.str() << std::endl;
	for (auto it = this->_players.begin(); it != this->_players.end(); it++)
	{
		User* u = *it;
		Helper::sendData(u->getSocket(), msg.str());
	}
}

void Game::sendFirstQuestion()
{
	sendQuestionsToAllUsers();
}

bool Game::handleAnswerFromUser(User* user, int answerNo, int time)
{
	if (this->_currQuestionIndex > this->_questions.size())
	{
		return false;
	}
	this->_curretTurnAnswers++;
	int ti = this->_questions[this->_currQuestionIndex]->getCorrectAnswerIndex();
	std::string* anss = this->_questions[this->_currQuestionIndex]->getAnswers();
	bool got_it = false;
	if (answerNo < 5)
	{
		if (anss[ti] == anss[answerNo])
		{
			this->_results[user->getUsername()]++;
			got_it = true;
		}
		this->_db.addAnswerToPlayer(this->_id, user->getUsername(), this->_questions[this->_currQuestionIndex]->getId(),
			anss[answerNo-1], got_it, time);
	}
	else
	{
		this->_db.addAnswerToPlayer(this->_id, user->getUsername(), this->_questions[this->_currQuestionIndex]->getId(),
			"", false, time);
	}
	got_it ? Helper::sendData(user->getSocket(), std::to_string(TRUE_ANSWER)) :
		Helper::sendData(user->getSocket(), std::to_string(FALSE_ANSWER));

	handleNextTurn();
	return true;

}

void Game::handleFinishGame()
{
	this->_db.updateGameStatus(this->_id);
	std::stringstream msg;
	msg << std::to_string(GAME_CLOSE);
	msg << std::to_string(this->_players.size());
	for (auto it = this->_players.begin(); it != this->_players.end(); it++)
	{
		User* u = *it;
		msg << std::setfill('0') << std::setw(2) << u->getUsername().length() << u->getUsername();
		msg << std::setfill('0') << std::setw(2) << this->_results[u->getUsername()];
	}

	std::cout << "end current game ! " << std::endl;
	std::cout << msg.str() << std::endl;
	for (auto it = this->_players.begin(); it != this->_players.end(); it++)
	{
		User* u = *it;
		try
		{
			u->setGame(nullptr);
			Helper::sendData(u->getSocket(), msg.str().c_str());
		}
		catch (const std::exception&)
		{
			continue;
		}
	}
}

bool Game::handleNextTurn()
{
	if (this->_players.empty())
	{
		handleFinishGame();
		return false;
	}
	if (this->_curretTurnAnswers == this->_players.size())
	{
		if (this->_currQuestionIndex == this->_questions.size()-1)
		{
			handleFinishGame();
		}
		else
		{
			this->_currQuestionIndex++;
			sendQuestionsToAllUsers();
		}
	}
	return true;
}

int Game::getID()
{
	return this->_id;
}

bool Game::leaveGame(User* currUser)
{

	auto it = std::find(this->_players.begin(), this->_players.end(), currUser);
	this->_players.erase(it);
	if (this->_players.empty())
	{
		handleFinishGame();
		return false;
	}
	handleNextTurn();
	return true;
}

bool Game::insertGameToDB()
{
	try
	{
		this->_id = this->_db.insertNewGame();
	}
	catch (const std::exception& e)
	{
		return false;
	}
	return true;

}

void Game::initQuestionsFromDB()
{
	this->_questions = this->_db.initQuestions(this->_questions_no);
}

Game::~Game()
{
}
