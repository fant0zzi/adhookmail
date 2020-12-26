# adhookmail 

AddHookMail (the name refers to ad hoc mailing) is supposed to be a service of disposable email addresses demonstrating a microservice approach.
At the moment it consists of:
1) The SMTP server (Python 3.9) which listens for inbound SMTP email and sends it to database. 
2) MessageRepositoryService (.NET 5) which is an API for database interractions. 
3) MongoDB 
All components are run in separate containers via Docker Compose.
