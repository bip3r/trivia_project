#pragma once
class Protocol
{
//CLIENT:
#define SIGN_IN 200 // USER SIGN IN REQUEST
#define SIGN_OUT 201 // USER SIGN OUT REQUEST
#define SIGN_UP 203 // USER SIGN UP REQUEST
#define ROOM_LIST_REQUEST 205 // USER REQUESR ROOM LIST
#define ROOM_REQUEST_USERS 207 //REQUEST USERS IN ROOM
#define JOIN_ROOM 209 // USER JOIN ROOM.
#define CREATE_ROOM 213 // USER CREATE ROOM
#define LEAVE_ROOM 211
#define CLOSE_ROOM 215
#define START_GAME 217
#define ANSWER 219
#define LEAVE_GAME 222
#define GET_SCORE 223
#define GET_PERSONAL_STATS 225
#define EXIT_APPLICATION 299
//SERVER:
#define SIGN_IN_SUCCESS 1020 // server successed sign in user
#define SIGN_IN_WRONG_DETAILS 1021 // server failed sign in user - wrong details.
#define SIGN_IN_CONNECTED 1022 // server failed sign in user - user already connected
#define SIGN_UP_SUCCESS 1040 // server success sign up user.
#define SIGN_UP_PASS_ILLEGAL 1041 // server faild - password illegal
#define SIGN_UP_EXISTS 1042 // server faild - user exists in the system
#define SIGN_UP_USER_ILLEGAL 1043 // server faild - username illegal
#define SIGN_UP_OTHER_ERROR 1044 // server faild - other error
#define ROOM_LIST_RESPONSE 106 // sends room list
#define PLAYERS_IN_ROOM 108 // sends list of players in a room
#define EMPTY_ROOM 1080 // code for empty room
#define JOIN_ROOM_SUCC 1100 // success joining room
#define JOIN_ROOM_FULL 1101 // fail join room - room full
#define JOIN_ROOM_OTHER 1102 // fail join room - other
#define CREATE_ROOM_SUCCESS 1140 // success creating room.
#define CREATE_ROOM_FAIL 1141 // failed creating rooms.
#define SEND_QUESTION 118 // sends question protocol.
#define TRUE_ANSWER 1201 
#define FALSE_ANSWER 1200
#define GAME_CLOSE 121
#define SCORES 124
#define PERSONAL_STATS 126
public:
	Protocol();
	~Protocol();
};

