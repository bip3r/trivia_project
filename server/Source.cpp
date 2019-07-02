#include "TriviaServer.h"

int main()
{
	TriviaServer* ts = new TriviaServer();
	try
	{
		ts->server();
	}
	catch (const std::exception& e)
	{
		std::cout << e.what() << std::endl;
	}
	system("pause");
	return 0;
}