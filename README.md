# ClientCalendar
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
![HotChocolate](https://img.shields.io/badge/HOT%20CHOCOLATE-%2320232a.svg?style=for-the-badge&logo=hotchocolate&logoColor=%2361DAFB)
![Apollo-GraphQL](https://img.shields.io/badge/-ApolloGraphQL-311C87?style=for-the-badge&logo=apollo-graphql)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)
![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)

ClientCalendar is a powerful tool that allows you to create, manage, and assign calendars to your clients or customers, streamlining your scheduling and timeline management.

## Key Features
- **Custom Calendar Creation**: Easily create and customize calendars tailored to your specific needs.
- **Client Assignment**: Assign clients or customers to specific time slots on your calendar for better scheduling and tracking.
- **Optimized for Performance**: Separate read and write operations using specialized API communicators to enhance performance and scalability.
  
## Technology Used
ClientCalendar leverages a unique approach to API communication by separating **read** and **write** operations into distinct API mechanisms:

![GraphQL](https://img.shields.io/badge/-GraphQL-E10098?style=for-the-badge&logo=graphql&logoColor=white)
![REST API](https://img.shields.io/badge/-REST%20API-808080?style=for-the-badge&logoColor=white)


- **Write Operations**: Powered by *REST API*, enabling secure and efficient data writing processes.
- **Read Operations**: Utilizes *GraphQL* for reading data, allowing for flexible and precise data retrieval.
### Why This Approach?
The decision to use REST for write operations and GraphQL for read operations is rooted in optimizing performance and scalability:

- **REST for Writes**: REST APIs are ideal for handling complex transactions and ensure data integrity during write operations.
- **GraphQL for Reads**: GraphQL allows clients to query only the data they need, reducing the amount of data transferred and improving response times. Also you **write code once**, no need to write useless endpoints to retrive specific data. It has built in **filters**, **sortings** and **paginations** makes it perfect for reading/querying data! 
  
By separating these concerns, ClientCalendar ensures that both writing data and retrieving data are handled in the most efficient manner possible.

## Technology Stack
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
![HotChocolate](https://img.shields.io/badge/HOT%20CHOCOLATE-%2320232a.svg?style=for-the-badge&logo=hotchocolate&logoColor=%2361DAFB)
![Apollo-GraphQL](https://img.shields.io/badge/-ApolloGraphQL-311C87?style=for-the-badge&logo=apollo-graphql)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)
![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)
