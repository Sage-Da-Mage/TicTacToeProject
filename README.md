# **TicTacToeProject**


## **Summary/Initial notes:**

This project allows those using it to create and play games of TicTacToe as well as to access information about games that have yet to be completed.

You can make use of this project by cloning it from this GitHub page onto your computer and run it through your IDE of choice (though I used Visual Studio 2019 and would recommend you do it for the most consistency with my experience).


## **Endpoint 1: Starting A Game**

Before you actually start a game itself, you are going to want to create some players in the Database so that the game can know who is playing. 

 - This can be done by using: http://localhost:6902/api/Player/Create to create a new player. 
 
 - A Game requires two players to start a game so please make sure you have at least 2 players in the database before you try to start one.
 
 After doing this, you can create a game by using: http://localhost:6902/api/Game/Create with a JSON string in the body in the format of:
'{
    "PlayersIds": ["GuidPlayerId", "GuidPlayer2Id"],
    "PlayerStarting": "OneOfTheAboveGuidPlayerIds",

    "Draw": false,
    "Completed": false,
    "Victor": null,
    "BoardList": [5,5,5,5,5,5,5,5,5]
}'


## **Endpoint 2: Move Implementation**

The Move endpoint: http://localhost:6902/api/Game/move allows a player to place their mark 1(player1)/2(player2) upon a Tile location specified in the body.

- A player can only make a move if it is a game they were one of the two players the game was started with and if it is your turn. Otherwise, it will throw an exception.

- The TicTacToe grid is formatted as a grid of integer with the locations being:

0 | 1 | 2
----------
3 | 4 | 5
----------
6 | 7 | 8

- Because of this, numbers outside the range of 0-8 will cause an Exception to be thrown so please keep the TileSelected to within that range.

- When calling the move endpoint a JSOn string needs to be in the body in the format of:

'{
    "GameId": "gameIdDesired",
    "PlayerId": "playerIdWhosTurnItIs",
    "TileSelected": IntRelatingTOTileLocation
}'

## **Endpoint 3: GetActiveGames**

This endpoint pulls the Games which haven't been completed at the time of calling the endpoint and returns the game GuidId as well as the names and number of moves each player has made.

The call for this endpoint is: http://localhost:6902/api/Game/getCurrentlyActiveGames?pageNumber=AnInteger&setsPerPage=AnotherInteger 

- This call takes data in from the Query so there isn't any JSON string in the body for this one.

- The setsPerPage indicates how many games(assuming maximum capacity on the given page) and their associated data (player names & moves taken) will appear on each "page". This is because with no set upper limit there needed to be a way to limit the amount of data presented at once. 

- The pageNumber is the page which you are selecting the data sets from, the games are ordered by the time they were created so the most recently created games will appear on the first page, going farther back the more pages you go back.


***
## **Final Question: What is the appropriate OAuth/OIDC grant to use for a web application using a SPA and why?**

In the context of a web application using a SPA (Single Page Application) then it should be using an authorization code flow with PKCE (Proof Key for Code Exchange) for its OAuth/OIDC (OpenIDConnect) grant. There are several reasons for this, chiefly being that SPAs often use the same client credentials for every instance of the application. This has led to them being referred to as "public clients" since there are real difficulties/issues trying to keep those credentials secret. 

PKCE helps resolve this issue by requiring that client apps (the SPA) provide proof to the authorization server that the authorization code belongs to the client app before being issued an access token. This is done through a code verifier, a code challenge, and a code challenge method (though this is optional).


The flow of such a process (including a code challenge method) would go as such:

1. The client sends an authorization request along with the *code challenge* and the *code challenge method*.

2. The Authorization server would then make note of the *code challenge* and the *code challenge method* and issue an auth code.

3. The client would, in response send an *access token* along with the *code verifier* back to the server.

4. The authorization server then validates the *code verifier* against the *code challenge* and *code challenge method* it had already received to make sure that there are no issues. If the Validation is successful, then the authorization server would issue an *access token* to the client. 


The reason this works is that neither the *code challenge* or *code verifier* can be intercepted. They should also only be used once per token requesting cycle to further improve the security of the process. This is the system that Auth0 uses, and it is why if we change applications, or from Swagger to Postman, I would need to get another access token.   

It is for this reason that an Authorization Code Flow with PKCE is the appropriate OAuth/OIDC grant for a web application using a SPA, it minimizes security issues that are vulnerable to attack under an Implicit Grant/OIDC Implicit Flow. 


