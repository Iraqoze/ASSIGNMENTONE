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

    
   <h1>Post Category</h1>
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
<h1> UserAuth Controller</h1>
<p> This UserAuth Controller performs all the user related operations</p>
