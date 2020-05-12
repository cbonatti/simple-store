# simple-store

## This project provides 2 solutions:
- Store Management;
- Store Consumer;

*Both solutions should be running at the same time.*

## Store Management
#### Frontend
It's a Angular application which has 2 screens: search products and product details.

#### Backend
It's a dotnet core solution which is responsible for getting frontend requests, validating and storing data.
After any Create, Update and Delete operation, a request is made for Store Consumer's API.

## Store Consumer
#### Backend
It's a dotnet core solution which just has a API to getting data from Store Management. It does not validate data, just store it.
