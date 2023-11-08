# Dog API 🐶🦴💾

Create and Read parts of a CRUD API, i.e. a CR API (pronounced KERRRR 🙃).



## Dog Entity


This data type represents how the API is expected to respond with a Dog that is persited on the backend.


| field | type | format | required |
| :--- | :--- | :--- | :--- |
| id | string | uuid | ✅ |
| birthDate | string | ISO Date | ✅ |
| breed | string |  |  |
| name | string |  | ✅ |


Here's an example of how that payload might look like:


```json
{
   "id":"eedf7f04-a4c4-4049-876d-fad6413bb435",
   "birthDate":"2022-02-02",
   "breed":"Rough Collie",
   "name":"Lassie"
}


```


## Dog Request Entity
This data type represent how the API should expect a Dog as request payload:
| field | type | format | required |
| :--- | :--- | :--- | :--- |
| birthDate | string | ISO Date | ✅ |
| breed | string |  |  |
| name | string |  | ✅ |


Here's an example of how that payload might look like:


```json
{
   "birthDate":"2022-02-02",
   "breed":"Rough Collie",
   "name":"Lassie"
}


```
## Endpoints
This section describes the endpoints that you're expected to implement.
### `POST /dogs`


This endpoint creates/persists a new dog on the server


| Body | Content-Type | Response
| :--- | :--- | :--- |
| [Dog Request](#dog-request-entity) | `application/json` |  [Dog](#dog-entity) |


The expected status codes are


| Status Code | Description |
| :--- | :--- |
| 200 | `OK` |
| 400 | `BAD REQUEST` |


### `GET /dogs`
This endpoint returns an array of all dogs. In the case where there are no existing dogs, it's fine to return an empty array.


| Body | Content-Type | Response
| :--- | :--- | :--- |
| `NONE` | `application/json` |  [Dog](#dog-entity)[] |


The expected status codes are


| Status Code | Description |
| :--- | :--- |
| 200 | `OK` |




### `GET /dogs/:id`


This endpoint returns a [Dog](#dog-entity) given its `id` provided as a parameter in the path.


The expected status codes are


| Status Code | Description |
| :--- | :--- |
| 200 | `OK` |
| 400 | `BAD REQUEST` |
| 404 | `NOT FOUND` |


## Test
Since we are mostly interested in how you solve a problem rather than checking if you have covered all edge-cases. We have provided a testfile for you to run and validate your solutions against.


To install all the dependencies for the test, execute the following command:


```bash
pip3 install -r requirements.txt
```


This can be executed from the root of this repository via:
```bash
python3 test.py <URL_TO_YOUR_API>
```


## Submitting

When you are finished with the implementation, please share the code with us so that we can review it.
Please add some information on how to start your server and any dependencies in the section below. Bonus points if you package your application with Docker, but it's not required for this task.


## How to run

The applicatation is built and runs with Docker (configured for Windows OS/Architecture).
Therefor Docker must to be installed (https://docs.docker.com/desktop/install/windows-install/) if not already.

prerequisites:
   - Windows OS
   - Docker engine/server installed

Onced installed, navigate to project root folder and run following commands

```bash
docker build -t dogapi . (builds image)
docker run -d -p 8080:80 --name dogapicontainer dogapi (intiliaze image/run conatiner)
```
The contaioner then listens on tcp port 8080
You can view the API specification in Swagger UI
```bash
./swagger/index.html
```

A ready image can also be pulled from gealea/dogapi (docker hub)
```bash
docker pull gealea/dogapi
```
