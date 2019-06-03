# IMDbReplicaResourceServer

Title
<IMDb replica resource server - API.>

URL

https://localhost:44337

Method:

GET

URL Params

Optional:

numberOfItemsToTake=[number]
movieType=[0 | 1] - (0 for movie, 1 for tv show)

movieId=[number]

Data Params

None

Success Response:

<What should the status code be on success and is there any returned data? This is useful when people need to to know what their callbacks should expect!>

Code: 200 
Content: { id : 12 }
Error Response:

<Most endpoints will have many ways they can fail. From unauthorized access, to wrongful parameters etc. All of those should be liste d here. It might seem repetitive, but it helps prevent assumptions from being made where they should be.>

Code: 401 UNAUTHORIZED 
Content: { error : "Log in" }
OR

Code: 422 UNPROCESSABLE ENTRY 
Content: { error : "Email Invalid" }
Sample Call:

Method:

PATCH

URL Params

Required:

movieId=[number]

Data Params

rating=[number]

httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': `Bearer ${this.auth.getToken()
        }



Notes:

IMPORTANT:
1. Clone or download -> Download ZIP
2. Open downloaded project via Visual Studio 
3. Wait untill VS load project and get necessary dependencies.
4. On toolbar select View -> Other windows -> Package manager console
5. Run command: update-database (in order to create database from already prepared migration)
6. Run project
