#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include "DataBase.h"
#include <exception>
#include <set>
#include <time.h>
#include <chrono>
#include <ctime>
sqlite3* db;
std::vector<std::string> results = {};

std::string getNumberOfRightWrongAnswers(std::string username, bool is_correct);
std::string getAverageTimeForAnswer(std::string username);
std::string getNumberOfGames(std::string username);
std::string getNumberOfGames(std::string username);
std::string getLastId(std::string tableName);
std::string getCurrentTime();
int callback(void* data, int argc, char** argv, char** azColName);
DataBase::DataBase()
{
	int rc = sqlite3_open("trivia.db", &db);
	char *zErrMsg = 0;
	if (rc) {
		fprintf(stderr, "Can't open database: %s\n", sqlite3_errmsg(db));
	}
	else {
		fprintf(stderr, "Opened database successfully\n");
	}
	//rc = sqlite3_exec(db, "select seq from sqlite_sequence where name='t_games';", callback, 0, &zErrMsg);
	if (rc) {
		fprintf(stderr, "Can't open database: %s\n", sqlite3_errmsg(db));
	}
}

DataBase::~DataBase()
{
	sqlite3_close(db);
}

int callback(void* data, int argc, char** argv, char** azColName)
{
	int i = 0;
	//fprintf(stderr, "%s: ", (const char*)data);
	for (i = 0; i < argc; i++)
	{
		printf("%s = %s\n", azColName[i], argv[i] ? argv[i] : "NULL");
	}
	printf("\n");
	return 0;
}

int saveResults(void* data, int argc, char** argv, char** azColName)
{
	for (int i = 0; i < argc; i++)
	{
		results.push_back((azColName[i], argv[i] ? argv[i] : "NULL"));
	}
	return 0;
}

int DataBase::callbackCount(void* data, int argc, char** argv, char** azColName)
{
	return callback(data, argc, argv, azColName);
}

int DataBase::callbackQuestions(void* data, int argc, char** argv, char** azColName)
{
	return callback(data, argc, argv, azColName);
}

int DataBase::callbackBestScored(void* data, int argc, char** argv, char** azColName)
{
	return callback(data, argc, argv, azColName);
}

int DataBase::callbackPersonalStatus(void* data, int argc, char** argv, char** azColName)
{
	return callback(data, argc, argv, azColName);
}

int callbackValidUsername(void* data, int argc, char** argv, char** azColName)
{
	if (argc % 2 == 0)
	{
		return true;
	}
	return false;
}

bool ActionInDataBase(const char* sql)
{
	bool exist = true;
	int rc = 0;
	char *zErrMsg = 0;
	rc = sqlite3_exec(db, sql, callback, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		std::cout << rc << std::endl;
		sqlite3_free(zErrMsg);
		exist = false;
	}
	return exist;
}

bool DataBase::isUserExists(std::string username)
{
	std::string msg = "select username from t_users where username = '" + username+"';";
	return ActionInDataBase(msg.c_str());
}

bool DataBase::addNewUser(std::string username, std::string password, std::string email)
{
	std::string msg = "insert into t_users (username, password, email) Values('" + username + "', '" + password + "', '" + email+"');";
	std::cout << msg << std::endl;
	return ActionInDataBase(msg.c_str());
}

bool DataBase::isUserAndPassMatch(std::string username, std::string password)
{
	std::string msg = "select username, password from t_users where username ='" + username +"' and password ='" + password+"';";
	std::cout << msg << std::endl;
	char* zErrArg;
	return sqlite3_exec(db,msg.c_str(),callbackValidUsername,NULL,&zErrArg);
}

std::vector<Question*> DataBase::initQuestions(int questionsNo)
{
	std::vector<Question*> questions = {};
	int rc = 0;
	char *zErrMsg = 0;
	rc = sqlite3_exec(db, "select question_id from t_questions", saveResults, NULL, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
	}
	for (size_t i = 0; i < results.size(); i++)
	{
		std::cout << results[i] << std::endl;
	}
	if (results.size() != 0)
	{
		std::set<int> indexes = {};
		srand(time(NULL));
		std::cout << "rand numbers:" << std::endl;
		while (indexes.size() < questionsNo)
		{
			int num = rand() % results.size()+1;
			indexes.insert(num);
			std::cout << num << ",";
		}
		std::cout << std::endl;
		std::set<int>::iterator it;
		results.clear();
		int index = 0;
		int id = 0, j = 0;
		for (it = indexes.begin(); it != indexes.end(); it++)
		{
			std::string q = "select * from t_questions where question_id=" + std::to_string(*it)+";";
			std::cout << q << std::endl;
			rc = sqlite3_exec(db, q.c_str(), saveResults, NULL, &zErrMsg);
			if (rc != SQLITE_OK)
			{
				fprintf(stderr, "SQL error: %s\n", zErrMsg);
				sqlite3_free(zErrMsg);
			}
			std::cout << "results where id is : " << *it << std::endl;
			for (size_t i = 0; i < results.size(); i++)
			{
				std::cout << results[i] << std::endl;
			}
			std::cout << std::endl;
			questions.push_back(new Question(*it, results[1], results[2], results[3], results[4], results[5]));
			results.clear();
		}
	}
	results.clear();
	return questions;
}

int DataBase::insertNewGame()
{
	int rc = 0;
	char *zErrMsg = 0;
	std::string id = getLastId("t_games");

	std::string msg = "insert into t_games (game_id, status, start_time, end_time) values(" + id + ", 0, '" + getCurrentTime() + "', 'null');";
	std::cout << msg << std::endl;
	rc = sqlite3_exec(db, msg.c_str() , NULL, NULL, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
	}
	return std::stoi(id);
}

std::string getLastId(std::string tableName)
{
	std::string id = "";
	int rc = 0, temp = 0;
	char *zErrMsg = 0;
	std::string msg = "select seq from sqlite_sequence where name='"+tableName+"';";
	std::cout << msg << std::endl;
	rc = sqlite3_exec(db, msg.c_str(), saveResults, NULL, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
	}
	else
	{
		id = results[0];
		temp = std::stoi(id);
		temp++;
		id = std::to_string(temp);
	}
	results.clear();
	return id;
}

bool DataBase::updateGameStatus(int id)
{
	bool update_succeeded = true;
	char *zErrMsg = 0;
	std::string msg = "update t_games set status = 1, end_time='" + getCurrentTime() + "' where game_id= " + std::to_string(id);
	std::cout << msg << std::endl;
	int rc = sqlite3_exec(db, msg.c_str(), saveResults, NULL, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
		update_succeeded = false;
	}
	return update_succeeded;
}

std::string getCurrentTime()
{
	time_t now = time(0);
	tm *ltm = localtime(&now);
	return std::to_string(ltm->tm_year) + "-" + std::to_string(ltm->tm_mon) + "-" + std::to_string(ltm->tm_mday) + " " + std::to_string(ltm->tm_hour) + ":" + std::to_string(ltm->tm_min) + ":" + std::to_string(ltm->tm_sec);
}

bool DataBase::addAnswerToPlayer(int gameId, std::string username, int questionId, std::string answer, bool isCorrect, int answerTime)
{
	bool insert_succeeded = true;
	char *zErrMsg = 0;
	std::string msg = "insert into t_players_answers (game_id, username, question_id, player_answer, is_correct, answer_time) values (" + std::to_string(gameId) + ", '" + username + "', " + std::to_string(questionId) + ", '" + answer + "', " + std::to_string(isCorrect) + ", " + std::to_string(answerTime) + ")";
	std::cout << msg << std::endl;
	int rc = sqlite3_exec(db,msg.c_str() , NULL, NULL, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
		insert_succeeded = false;
	}
	return insert_succeeded;
}

std::vector<std::string> DataBase::getBestScores()
{
	std::vector<std::string> best_scores = {};
	char *zErrMsg = 0;
	int rc = sqlite3_exec(db, "select username, count(*) from t_players_answers where is_correct = 1 group by username order by count(*) desc limit 6;", saveResults, NULL, &zErrMsg);
	//int rc = sqlite3_exec(db, "select * from t_players_answers", saveResults, NULL, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
	}
	
	else
	{
		int count = 0;
		while (count < 6)
		{
			best_scores.push_back(results[count]);
			count++;
		}
	}
	results.clear();
	return best_scores;
}

std::vector<std::string> DataBase::getPersonalStatus(std::string username)
{
	std::vector<std::string> personal_status = {};
	personal_status.push_back(getNumberOfGames(username));
	results.clear();
	personal_status.push_back(getNumberOfRightWrongAnswers(username, true));
	results.clear();
	personal_status.push_back(getNumberOfRightWrongAnswers(username, false));
	results.clear();
	personal_status.push_back(getAverageTimeForAnswer(username));
	results.clear();
	return personal_status;
}

std::string getNumberOfGames(std::string username)
{
	std::string number_of_games = "";
	char *zErrMsg = 0;
	std::string msg = "select count(*) from (select distinct game_id from t_players_answers where username ='" + username + "')";
	std::cout << msg << std::endl;
	int rc = sqlite3_exec(db,msg.c_str() , saveResults, NULL, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
	}
	number_of_games = results[0];
	results.clear();
	return number_of_games;
}

std::string getNumberOfRightWrongAnswers(std::string username, bool is_correct)
{
	std::string number_of_right_wront_answers = "";
	char *zErrMsg = 0;
	std::string msg = "select count(*) from t_players_answers where username='" + username + "' and is_correct = " + std::to_string(is_correct);
	std::cout << msg << std::endl;
	int rc = sqlite3_exec(db,msg.c_str() , saveResults, NULL, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
	}
	number_of_right_wront_answers = results[0];
	results.clear();
	return number_of_right_wront_answers;
}

std::string getAverageTimeForAnswer(std::string username)
{
	std::string ave_time_for_answer = "";
	double ave = 0;
	char *zErrMsg = 0;
	std::string msg = "select avg (answer_time) from t_players_answers where username ='" + username+"'";
	std::cout << msg << std::endl;
	int rc = sqlite3_exec(db, msg.c_str(), saveResults, NULL, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
	}
	ave_time_for_answer = results[0];
	results.clear();
	return ave_time_for_answer;
}