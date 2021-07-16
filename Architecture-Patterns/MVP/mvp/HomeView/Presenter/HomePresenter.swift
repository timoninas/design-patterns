import Foundation

class HomePresenter: HomePresenterOutput {
    private var view: HomePresenterInput
    private var person: Person
    
    required init(view: HomePresenterInput, person: Person) {
        self.view = view
        self.person = person
    }
    
    func setGreeting() {
        let greeting = "\(person.name)\n\(person.text)"
        self.view.setGreeting(greeting: greeting)
    }
}
