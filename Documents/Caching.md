SYSTEM DESIGN

DESIGN SCENARIO (Core Functionality):
Design a ticketing system for a high-traffic event platform. The system should handle 
thousands of concurrent users buying tickets.

UNIQUE VALUE PROPOSITION:
Provide a consolidated and streamlined event platform that allows users to purchase tickets
for multiple events across multiple locations (bot local and global). 
The system should provide the following features:
1. Login and Role based access - User, Event Organiser, Admin.
2. Visualization for seating layout - if event supports seating.
3. Booking option with 3rd party payment gateway API integration - e.g. Mastercard, Paypal, Stripe.
4. Event updates - booking status, event cancellations, event reminder.
5. Support for local and global currency.
6. Highlight top selling events.
7. For Organiser - event statistics (Profitable events, Demands by location, audience data etc.).

REQUIREMENT GATHERING:

Functional Requirements:
- Users can book tickets for single/multipe events across the globle.
- Users can track or get notified regarding event and booking status.
- Event organisers can manage (create/update/delete/look up) multiple events.
- Log in access with separate function for users and event organiser.
- Top selling events are highlighed.
- Most expensive events are highlighed.
- Ability to download & print ticket info.
- Analytics on event performance (success/failure/top selling/ location) - For event organiser.
- Payment gateway supporting multiple currency.

Non-Functional Requirements:
- Fast and responsive interface.
- Caching.
- API based interaction (REST API)
- Works on both mobile phones and laptop.
- Secure payment gateway.
- Secure user/organiser data storage.
- Transaction logging.
- Event update loggig.
- Messaging system for notificationn.
- Scalable.
- Load balancing - using cloud.
- End-to-End testing.


TECHNOLOGY:

Frontend:
- Angular Framework (TypeScript) or ReactJS (JavaScript)
- HTML & CSS

Backend:
- C# .NET Framework
- Entity Framework or NHibernate for Database interaction

Database:
- Microsoft SQL Server (SSMS)

Testing:
- Cypress framework for frontend testing
- NUnit or MSTest framework for backend testing

Authentication:
- JWT token based Authentication

Deployment
- IIS or Azure

CI/CD:
- Git pipelines

Source code:
- GitHub or GitLab

Documentation:
- Confluence





