# metacritic-api
This is now deployed.

You can use the ff endpoints:
```
api.marcalencc.com/metacritic/<mediaType>/<title-separated-by-a-dash>
api.marcalencc.com/metacritic/<mediaType>/<title-separated-by-a-dash>/<year>
api.marcalencc.com/metacritic/<mediaType>/<title-separated-by-a-dash>/<details>
api.marcalencc.com/metacritic/<mediaType>/<title-separated-by-a-dash>/<year>/<details>
api.marcalencc.com/metacritic/person/<name-separated-by-a-dash>/<mediaType>

<mediaType> = album|tvshow|movie
<year> = specify the release year e.g (2015) or season for tv shows e.g. (6) to filter the results
<details> = to get the item credits instead of the item info and reviews

Note: If the name or title has a '-', prefix it with a '~' e.g (/person/jay~-z/album)
```
# Example

Request: http://api.marcalencc.com/metacritic/tvshow/the-big-bang-theory/1<br/><br/>
Response:
```json
[  
   {  
      "Season":1,
      "Studio":"CBS",
      "Title":"The Big Bang Theory",
      "ReleaseDate":"09/24/2007",
      "Rating":{  
         "CriticRating":57,
         "CriticReviewCount":23,
         "UserRating":8.0,
         "UserReviewCount":1270
      },
      "ImageUrl":"http://static.metacritic.com/images/products/tv/0/16d908fb64cd4719701eb83f7c787dce-53.jpg"
   }
]
```
