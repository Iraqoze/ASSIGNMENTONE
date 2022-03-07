# Movie-Entertainment-Group5
<h2>Movie Entertainment API - Group 5 Class Project</h2>

<h1>Getting Started</h1><br>

<b><h3>Root Url: https://movieentx.azurewebsites.net/api/ </h3></b><br>  
  
  
<h1> Category Controller</h1>
  <p> This category Controller performs all the CRUD related operations on the Category Table</p>
  
  <h1>Getting All Categories</h1>
  <h3>GET: categories/getcategories<h3>
  
    [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "title": "string",
        "description": "string"
      }
    ]
  
  <p>Getting Specific Category</p>
  <h3>GET: categories/getcategory/{CategoryId}<h3>
   
    {
       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
       "title": "string",
       "description": "string"
    }
    
   <p>Post Category</p>
  <h3>POST: categories/postcategory<h3>
  
    {
      "title": "string",
      "description": "string"
    }
  
    
  <p>Update Category</p>
  <h3>PUT: categories/updatecategory/{CategoryId}<h3>
    
    {
      "title": "string",
      "description": "string"
    }
    
   <p>Delete Category</p>
  <h3>GET: categories/deletecategory/{CategoryId}<h3> 
   
  
  <h1> Movie Controller</h1>
<p> This Movie Controller performs all the CRUD related operations on the Movie Table</p>
    
    
 <h1>Getting All Movies</h1>
    
  <h3>GET: movies/getmovies</h3>
      
    [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "title": "string",
        "description": "string",
        "releaseDate": "2022-03-07T11:16:21.055Z",
        "videoLink": "string",
        "thumbnailImage": "string",
        "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
      }
    ]
    
  
  <p>Getting Specific Movie</p>
  <h3>GET: movies/getmovie/{MovieId}<h3>
    
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "title": "string",
      "description": "string",
      "releaseDate": "2022-03-07T11:17:03.067Z",
      "videoLink": "string",
      "thumbnailImage": "string",
      "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    
   <p>Post Movie</p>
  <h3>POST: movies/postmovie/{categoryId}<h3>
    
    {
      "title": "string",
      "description": "string",
      "releaseDate": "2022-03-07T11:17:49.756Z",
      "videoLink": "string",
      "thumbnailImage": "string"
    }
    
    
  <p>Update Movie</p>
  <h3>PUT: movies/updatemovie/{MovieId}<h3>
    
    {
      "title": "string",
      "description": "string",
      "releaseDate": "2022-03-07T11:30:14.646Z",
      "videoLink": "string",
      "thumbnailImage": "string",
      "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    
   <p>Delete Movie</p>
  <h3>GET: movies/deletemovie/{MovieId}<h3> 
    
    
    
<h1> UserAuth Controller</h1>
<p> This UserAuth Controller performs all the user related operations</p>
 
<p>Login User </p>
    
<h3>POST: userauth/loginuser </h3> 
  {
    "email": "user@example.com",
    "password": "string",
    "rememberMe": true
  }
  
<p>Register User </p>
<h3>POST: userauth/registeruser </h3>     
  {
    "firstname": "string",
    "lastname": "string",
    "email": "user@example.com",
    "phoneNumber": "string",
    "password": "string",
    "confirmPassword": "string"
  }
  
<p>Update User </p>
<h3>POST: userauth/updateuser </h3>   
  {
    "firstname": "string",
    "lastname": "string",
    "id": "string",
    "username": "string",
    "email": "string",
    "phoneNumber": "string"
  }
