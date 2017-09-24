# metacritic-api

You can use the ff endpoints:
# SEARCH
```
api.marcalencc.com/metacritic/search/<dash-separated-search-string>/<mediaType>
<mediaType> = album|tvshow|movie
```
 # Example
 Request: http://api.marcalencc.com/metacritic/search/spider-man/movie<br/><br/>
 Response: 
 ```json
<snip>
[  
   {  
      "SearchItems":[  
         {  
            "Id":"/movie/spider-man-homecoming",
            "Title":"Spider-Man: Homecoming",
            "ReleaseDate":"July 7, 2017",
            "Genre":"Action, Adventure, Sci-Fi, Fantasy, Family",
            "Rating":{  
               "CriticRating":73
            }
         },
         {  
            "Id":"/movie/spider-man-2",
            "Title":"Spider-Man 2",
            "ReleaseDate":"June 30, 2004",
            "Genre":"Action, Sci-Fi, Thriller, Fantasy",
            "Rating":{  
               "CriticRating":83
            }
         },
         {  
            "Id":"/movie/the-amazing-spider-man-2",
            "Title":"The Amazing Spider-Man 2",
            "ReleaseDate":"May 2, 2014",
            "Genre":"Action, Adventure, Fantasy",
            "Rating":{  
               "CriticRating":53
            }
         },
</snip>
```
* Id field can then be used for subsequent requests. (See media requests below.)

* Limit and offset can be specified on search requests. Default and maximum limit is 20. Default offset is 0.
```
/search/<dash-separated-search-string>/<mediaType>?limit=15&offset=21
/search/<dash-separated-search-string>/<mediaType>?offset=15
/search/<dash-separated-search-string>/<mediaType>?limit=10
```

# PERSON
```
api.marcalencc.com/metacritic/person/<name-separated-by-a-dash>/<mediaType>
<mediaType> = album|tvshow|movie
```
 # Example
 Request: http://api.marcalencc.com/metacritic/person/car-seat-headrest/album<br/><br/>
 Response: 
```json
[  
   {  
      "Name":"Car Seat Headrest",
      "RatingsSummary":{  
         "HighestRating":86.0,
         "LowestRating":79.0,
         "ReviewCount":2,
         "AverageRating":82.5
      },
      "CreditMediaPairItems":[  
         {  
            "Credit":"Primary Artist",
            "Item":{  
               "Id":"/album/teens-of-denial",
               "Title":"Teens of Denial",
               "ReleaseDate":"05/20/2016",
               "Rating":{  
                  "CriticRating":86,
                  "UserRating":8.3
               }
            }
         },
         {  
            "Credit":"Primary Artist",
            "Item":{  
               "Id":"/album/teens-of-style",
               "Title":"Teens of Style",
               "ReleaseDate":"10/30/2015",
               "Rating":{  
                  "CriticRating":79,
                  "UserRating":6.9
               }
            }
         }
      ]
   }
]
```
* Id field can then be used for subsequent requests. (See media requests below.)

# MEDIA ITEM REQUEST
Alternatively, just plug in the dash separated title of the item being searched.
```
api.marcalencc.com/metacritic/<mediaType>/<title-separated-by-a-dash>
api.marcalencc.com/metacritic/<mediaType>/<title-separated-by-a-dash>/<year>
api.marcalencc.com/metacritic/<mediaType>/<title-separated-by-a-dash>/<details>
api.marcalencc.com/metacritic/<mediaType>/<title-separated-by-a-dash>/<year>/<details>

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

Request: http://api.marcalencc.com/metacritic/album/1989/2014<br/><br/>
Response:
```json
[  
   {  
      "PrimaryArtist":"Taylor Swift",
      "Title":"1989",
      "ReleaseDate":"10/27/2014",
      "Rating":{  
         "CriticRating":76,
         "CriticReviewCount":29,
         "UserRating":6.8,
         "UserReviewCount":1225
      },
      "ImageUrl":"http://static.metacritic.com/images/products/music/7/37d41a1210252e00054ab77139189533-53.jpg"
   }
]
```

Request: http://api.marcalencc.com/metacritic/movie/black-swan/details<br/><br/>
Response:
```json
<snip>
[  
   {  
      "Details":[  
         {  
            "Description":"Runtime",
            "Value":"108"
         },
         {  
            "Description":"Rating",
            "Value":"for strong sexual content, disturbing violent images, language and some drug use"
         },
         {  
            "Description":"Production",
            "Value":"Phoenix Pictures"
         },
         {  
            "Description":"Genres",
            "Value":"Drama, Thriller"
         },
         {  
            "Description":"Country",
            "Value":"USA"
         },
         {  
            "Description":"Language",
            "Value":"English"
         },
         {  
            "Description":"Home Release Date",
            "Value":"Mar 29, 2011"
         }
      ],
      "Credits":[  
         {  
            "Name":"Darren Aronofsky",
            "Credit":"Director"
         },
         {  
            "Name":"Andres Heinz",
            "Credit":"Story"
         },
         {  
            "Name":"John J. McLaughlin",
            "Credit":"Screenplay"
         },
         {  
            "Name":"Mark Heyman",
            "Credit":"Screenplay"
         },
</snip>         
```
