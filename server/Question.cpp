#include "Question.h"
#include <stdio.h>
#include <stdlib.h>
#include <random>


Question::Question(int id, std::string question, std::string correctAnswer, std::string answer2, std::string answer3,
	std::string answer4)
{
	int indexes[3] = {};
	this->_id = id;
	this->_question = question;
	this->_correctAnswerIndex = RandomizeAnswers(correctAnswer);
	indexes[0] = this->_correctAnswerIndex;
	indexes[1] = RandomizeAnswers(answer2);
	indexes[2] = RandomizeAnswers(answer3);
	this->_answers[6 - (indexes[0] + indexes[1] + indexes[2])] = answer4;
}

int Question::RandomizeAnswers(std::string answer)
{
	int index = 0;
	std::random_device rnd;
	index = rnd() % 4;
	while (this->_answers[index].length() > 0)
		index = rnd() % 4;
	this->_answers[index] = answer;
	return index;
}

Question::~Question()
{
}

std::string Question::getQuestion()
{
	return this->_question;
}

std::string* Question::getAnswers()
{
	return this->_answers;
}

int Question::getCorrectAnswerIndex()
{
	return this->_correctAnswerIndex;
}

int Question::getId()
{
	return this->_id;
}
