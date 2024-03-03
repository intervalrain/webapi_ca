# Mysln API
- [Mysln API](#Mysln-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "Rain",
    "lastName": "Hu",
    "email": "intervalrain@gmail.com",
    "password": "@12340987"
}
```