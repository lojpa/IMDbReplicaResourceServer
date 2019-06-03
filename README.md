# IMDbReplicaResourceServer

Title
IMDb replica resource server - API

URL

https://localhost:44337

Method:

GET

URL Params

Optional:

numberOfItemsToTake=[number]
movieType=[0 | 1] - (0 for movie, 1 for tv show)

Data Params

None

Success Response:

Code: 200 
Content: [ List<Movie> ]

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
        
Success Response:

Code: 200 


Error Response:

Code: 401 UNAUTHORIZED 
Content: { error : "Log in" }

Notes:

IMPORTANT:
1. Clone or download -> Download ZIP
2. Open downloaded project via Visual Studio 
3. Wait untill VS load project and get necessary dependencies.
4. On toolbar select View -> Other windows -> Package manager console
5. Run command: update-database (in order to create database from already prepared migration)
6. Run project
