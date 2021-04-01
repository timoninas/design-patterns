import Foundation

// MARK:- Presenter
// Протокол по которому Interactor будет взаимодействовать с Presenter
protocol MainPresenterOutputProtocol: class {
    init(view: MainViewInputProtocol, interactor: MainInteractorProtocol, router: RouterProtocol)
    func receivePersonData(person: Person)
}

// Протокол по которому Presenter будет взаимодействовать с View
protocol MainPresenterViewEventHandler: class {
    func didTapConfirmButton()
    func didTapDetailButton()
}


// MARK:- View
// Протокол по которому Presenter будет обращаться к View
protocol MainViewInputProtocol: class {
    func setPerson(person: Person)
}

// MARK:- Interactor
// Протокол по которому будут взаимодействовать с Interactor
protocol MainInteractorProtocol: class {
    init(dbManager: MainDBManagerProtocol)
    func providePersonData()
}

// MARK:- Entity
// Протокол по которому Interactor будет получать данные из БД
protocol MainDBManagerProtocol: class {
    func getPerson() -> Person?
}
