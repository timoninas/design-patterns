# Паттер Фасад

## Назначение

Облегчает задачу пользователю: есть много классов, которые последовательно выполняют какие-либо действия. 
Паттерн фасад берет выполнение всех этих действия на себя, скрывая их в своем методе. Этот метод фасада доступен пользовтелю.

## Листинг 

#### Facade.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Structural%20Patterns/Facade/Facade.swift)

```Swift
class User {
    private let _username: String
    private let _password: String
    
    
    init(username: String, password: String) {
        self._username = username
        self._password = password
    }
    
    func getUserInfo() -> (username: String, password: String) {
        return (_username, _password)
    }
}

class DB {
    private let _dbName: String
    
    init(dbName: String) {
        self._dbName = dbName
    }
    
    func getDB() -> [(username: String, password: String)] {
        let db : [(username: String, password: String)] = [("timoninas", "123456789"),
                                                           ("timonines", "ghIjfld"),
                                                           ("timoninss", "00let00var")]
        return db
    }
    
}

// FACADE
class Authorizator {
    private let _username: String
    private let _password: String
    private var _isAuthorizate: Bool = false
    
    init(user: User) {
        self._username = user.getUserInfo().username
        self._password = user.getUserInfo().password
    }
    
    func authorizate() {
        let db = DB(dbName: "DataBaseus")
        
        for user in db.getDB() {
            if user.username == self._username && user.password == self._password {
                _isAuthorizate = true
            }
        }
        
        if (_isAuthorizate) {
            print("\n\n \(self._username) is authorized!")
        } else {
            print("\n\n \(self._username) is NOT authorized!")
        }
    }
    
    func isAuthorizated() -> Bool {
        return self._isAuthorizate
    }
}

func main() {
    
    var auth = Authorizator(user: User(username: "timonines", password: "ghIjfld"))
    auth.authorizate()
    
    auth = Authorizator(user: User(username: "timoninas", password: "ghIjfld"))
    auth.authorizate()
}
```

#### Console

```Console
timonines is authorized!
timoninas is NOT authorized!
```
