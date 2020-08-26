import Foundation

protocol HomePresenterOutput {
    func setGreeting()
    init(view: HomePresenterInput, person: Person)
}
