import Foundation

class MainInteractor: MainInteractorProtocol {
    var dbManager: MainDBManagerProtocol!
    weak var presenter: MainPresenterOutputProtocol!
    
    required init(dbManager: MainDBManagerProtocol) {
        self.dbManager = dbManager
    }
    
    func providePersonData() {
        if let person = dbManager.getPerson() {
            presenter.receivePersonData(person: person)
        }
    }
}
