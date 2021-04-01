import Foundation

class MainPresenter: MainPresenterOutputProtocol, MainPresenterViewEventHandler {
    weak var view: MainViewInputProtocol!
    let interactor: MainInteractorProtocol!
    let router: RouterProtocol!
    
    required init(view: MainViewInputProtocol, interactor: MainInteractorProtocol, router: RouterProtocol) {
        self.view = view
        self.interactor = interactor
        self.router = router
    }
    
    func didTapConfirmButton() {
        interactor.providePersonData()
    }
    
    func didTapDetailButton() {
        router.detailModule(person: Person(firstName: "Some", lastName: "Name", age: 23))
    }
    
    func receivePersonData(person: Person) {
        view.setPerson(person: person)
    }
}
