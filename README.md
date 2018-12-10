# DbScrambler
Anonymize your database

## Scramblers
### Email
Hash the local part of the email and retain the domain.

Empty or null email return an empty string.
Invalid emails return invalid@example.com.

Example: 
Test@example.com => RqaOK2KlhH7p6fXkuwaMJFedviPc3VePnAUdl4fiuZg=@example.com
