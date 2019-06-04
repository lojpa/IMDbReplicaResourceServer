# IMDbReplicaResourceServer

Title
IMDb replica resource server - API

URL

https://localhost:44337/api/movie

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
Content: [ {id: 1, title: "Aladin 2019", imageUrl: "../../assets/images/aladin.jpg",description: "It's story about disney aladin.", releaseDate: "2019-05-31", cast: ["Steven Seagal, Jan Claude Van Damme"], movieType: 0},
{id: 2, title: "Godzilla: King of the Monsters(2019)", imageUrl: "../../assets/images/godzilla.jpg",description: "...", releaseDate: "2019-03-21", cast: ["Steven Seagal, Jan Claude Van Damme"], movieType: 0}, ...]

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
        'Authorization': 'Bearer some-token'
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
