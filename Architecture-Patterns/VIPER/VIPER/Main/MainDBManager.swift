import Foundation

class MainDBManager: MainDBManagerProtocol {
    func getPerson() -> Person? {
        return Person(firstName: "Anton", lastName: "Timonin", age: 21)
    }
}
