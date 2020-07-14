# Паттерн Пул объектов 

## Назначение 

Паттерн Пул объектов или Object pool предоставляет для программы ограниченный пул объектов, готовых к использованию.
Когда программе требуется объект, тогда он не инициальзируется, а берется из пула объектов. После использования, объект 
освобождается, для использования его, но уже другим объектом. Может быть так, что все объекты будут заняты, в таком случае
придется ждать освобождения

Отличным примером использования паттерна Object pool, будет загрузка фотографий из интернета. Например, вы 
хотите загрузить сразу 100 фотокарточек. Отправляете запрос на загрузку. Хорошая программа будет загружать одновременно
немного изображений одновременно, используя pool из 5 элементов, к примеру


## Листинг 

#### Object pool.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Object%20pool/Object%20pool.swift)

```Swift
enum TypeTransaction {
    case withdrawal
    case deposit
}

class User {
    let username: String
    let password: String
    
    init(username: String, password: String) {
        self.username = username
        self.password = password
    }
}

protocol Command {
    func execute()
}

class Transaction: Command {
    private let user: User
    let transactionID: Int
    private let typeAction: TypeTransaction
    private var balance: Double
    private var isDone: Bool
    var operationIsDone: Bool {
        return isDone
    }
    
    init(user: User, typeAction: TypeTransaction, howMuch: Double) {
        self.user = user
        self.transactionID = Int.random(in: (0...9999))
        self.typeAction = typeAction
        self.balance = howMuch
        self.isDone = false
    }
    
    func execute() {
        if typeAction == .deposit {
            deposit()
        } else if typeAction == .withdrawal {
            withdrawal()
        }
        
        self.isDone = true
    }
    
    private func deposit() {
        self.balance += 100
        print("Some logic deposit! ")
    }
    
    private func withdrawal() {
        self.balance -= 100
        print("Some logic withdrawal!")
    }
}

 // Pattern Object Pool
 // Паттерн Пул объектов
class ObjectPoolTransactions {

    // Сам пул объектов
    private var poolTransactions: [(Transaction, Bool)] = []
    
    init() {
        for _ in 0 ..< 5 {
            let user = User(username: "", password: "")
            let transaction = Transaction(user: user, typeAction: .deposit, howMuch: 0)
            
            let element = (transaction, true)
            poolTransactions.append(element)
        }
    }
    
    func acquire(transaction: Transaction) {
        for i in 0..<poolTransactions.count {
            if poolTransactions[i].1 == true {
                poolTransactions[i].1 = false
                poolTransactions[i].0 = transaction
                poolTransactions[i].0.execute()
                break
            }
        }
    }
    
    func release() {
        for i in 0..<poolTransactions.count {
            if poolTransactions[i].1 == false {
                poolTransactions[i].1 = true
                break
            }
        }
    }
}

func main() {
    let objectPool = ObjectPoolTransactions()
    
    let user1 = User(username: "timoninas", password: "123")
    let transaction1 = Transaction(user: user1, typeAction: .deposit, howMuch: 1000)
    
    let user2 = User(username: "timonines", password: "321")
    let transaction2 = Transaction(user: user2, typeAction: .deposit, howMuch: 0)
    
    let user3 = User(username: "timoninss", password: "321")
    let transaction3 = Transaction(user: user3, typeAction: .withdrawal, howMuch: 0)
    
    objectPool.acquire(transaction: transaction1)
    objectPool.acquire(transaction: transaction3)
    objectPool.acquire(transaction: transaction2)
    objectPool.release()
}
```
