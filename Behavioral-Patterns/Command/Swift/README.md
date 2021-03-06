# Паттерн Команда

## Демонстрация работы

![Command](https://github.com/timoninas/design-patterns/blob/master/Behavioral%20Patterns/Command/Command.gif)

## Листинг 

#### Command.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Behavioral%20Patterns/Command/Command.swift)

```Swift
import Foundation

class Account {
    var balance: Int
    var accountName: String
    
    init(accountName: String, balance: Int) {
        self.balance = balance
        self.accountName = accountName
    }
}

protocol Command {
    func execute()
    var isComplete: Bool {get set}
    var info: String { get }
}

class Deposit : Command {
    private var _amount: Int
    private var _account: Account
    var isComplete: Bool = false
    var info: String {
        return "\(_account.accountName) Deposit \(_amount); "
    }
    
    init(account: Account, amount: Int) {
        _account = account
        _amount = amount
        isComplete = false
    }
    
    func execute() {
        _account.balance += _amount
        isComplete = true
        
    }
}


class Withdrawal : Command {
    private var _amount: Int
    private var _account: Account
    var info: String {
        return "\(_account.accountName) Withdrawal \(_amount); "
    }
    var isComplete: Bool = false
    
    init(account: Account, amount: Int) {
        _account = account
        _amount = amount
    }

    func execute() {
        if _account.balance >= _amount {
            _account.balance -= _amount
            isComplete = true
        } else {
            isComplete = false
        }
    }
}

class TransactCenter {
    static let shared = TransactCenter()
    private var transactions = [Command]()
    
    func registerTransaction(newTrancaction: Command) {
        transactions.append(newTrancaction)
    }
    
    func processingTransactions() {
        for transaction in transactions {
            if transaction.isComplete == false {
                transaction.execute()
            }
        }
    }
    
    func getCompleteTransactions() -> [Command] {
        var tmpTrn = [Command]()
        
        for value in transactions where value.isComplete == true {
            tmpTrn.append(value)
        }
        
        return tmpTrn
    }
    
    func getPandingTransactions() -> [Command] {
        var tmpTrn = [Command]()
        
        for value in transactions where value.isComplete == false {
            tmpTrn.append(value)
        }
        
        return tmpTrn
    }
    
    private init() {}
}

```
