# Паттерн Цепочка обязанностей

## Назначение

В паттерне Цепочка обязанностей у вас есть некие цепочки, по которым объект должен проходить. 
В этой цепочке с объектом происходят различный проверки/манипуляции. 
В случае успеха проверки/манипуляции, объект идет к следующему этапу.
И так до крайнего этапа/крайней цепочки.

Программист устанавливает "цепочки" и в каком порядке по ним будет проходить объект. 
Эта гибкость является главной особенностью паттерна Chain of Responsibility

## Листинг 

#### Chain of Responsibility.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Behavioral%20Patterns/Chain%20of%20Responsibility/Chain%20of%20Responsibility.swift)

```Swift
import Foundation
import UIKit
import XCTest

// Pattern Chain of Responsibility
// Паттерн Цепочка обязанностей
enum AuthError: LocalizedError {
    case invalidUser
    case invalidPassword
    case invalidLocalization
    
    var errorDescription: String? {
        switch self {
        case .invalidUser:
            return "User is invalid"
        case .invalidPassword:
            return "Password is invalid"
        case .invalidLocalization:
            return "Localization is invalid"
        }
    }
}

struct Login {
    var username: String
    var password: String
    var passwordRepeated: String
    var country: String
    
    init(username: String, password: String, passwordRepeated: String, country: String) {
        self.username = username
        self.password = password
        self.passwordRepeated = passwordRepeated
        self.country = country
    }
}

// Realisation Pattern Chain of Responsibility
protocol Handler {
    var nextHandler: Handler? { get set }
    func setNext(handler: Handler) -> Handler
    func handle(request: Login) -> AuthError?
}

class CheckPasswordHandler: Handler {
    var nextHandler: Handler?
    
    func setNext(handler: Handler) -> Handler {
        self.nextHandler = handler
        return handler
    }
    
    func handle(request: Login) -> AuthError? {
        // Проверка на одинаковые пароли
        if request.password == request.passwordRepeated {
            print("Passwords: password - \(request.password) repeated password - \(request.passwordRepeated) is logined")
        } else {
            print("Error: \(AuthError.invalidPassword.errorDescription!)")
            return AuthError.invalidPassword
        }
        
        if nextHandler != nil {
            nextHandler?.handle(request: request)
        }
        
        return nil
    }
}

class LoginHandler: Handler {
    internal var nextHandler: Handler?
    
    func setNext(handler: Handler) -> Handler {
        self.nextHandler = handler
        return handler
    }
    
    func handle(request: Login) -> AuthError? {
        // Какая-нибудь проверка на корректность входа пользователя
        if true {
            print("User: \(request.username) \(request.password) is logined")
        } else {
            print("Error: \(AuthError.invalidUser.errorDescription!)")
            return AuthError.invalidUser
        }
        
        if nextHandler != nil {
            nextHandler?.handle(request: request)
        }
        
        return nil
    }
}

class LocalizationHandler: Handler {
    var nextHandler: Handler?
    
    func setNext(handler: Handler) -> Handler {
        self.nextHandler = handler
        return handler
    }
    
    func handle(request: Login) -> AuthError? {
        
        if request.country == "Germany" {
            print("Localization: \(request.country) is detected")
        } else {
            print("Error: \(AuthError.invalidLocalization.errorDescription!)")
            return AuthError.invalidLocalization
        }
        
        if nextHandler != nil {
            nextHandler?.handle(request: request)
        }
        
        return nil
    }
}

func main() {
    let user = Login(username: "Timoninas", password: "123", passwordRepeated: "123", country: "Germany")
    let checkPass = CheckPasswordHandler()
    let login = LoginHandler()
    let local = LocalizationHandler()
    
    checkPass.setNext(handler: login)
    login.setNext(handler: local)
    
    checkPass.handle(request: user)
}
```

#### Output
```Console
Passwords: password - 123 repeated password - 123 is logined
User: Timoninas 123 is logined
Localization: Germany is detected

```

