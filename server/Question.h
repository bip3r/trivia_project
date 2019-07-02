#pragma once
#include <string>
class Question
{
private:
	std::string _question;
	std::string _answers[4];
	int _correctAnswerIndex;
	int _id;

	int RandomizeAnswers(std::string);

public:
	Question(int, std::string, std::string, std::string, std::string, std::string _answer4);
	~Question();
	std::string getQuestion();
	std::string* getAnswers();
	int getCorrectAnswerIndex();
	int getId();
};

