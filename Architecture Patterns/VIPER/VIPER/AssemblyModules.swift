import UIKit

protocol AssemblyModulesProtocol: class {
    func mainModule(router: RouterProtocol) -> UIViewController
    func detailModule(router: RouterProtocol, person: Person) -> UIViewController
}

class AssemblyModules: AssemblyModulesProtocol {
    func mainModule(router: RouterProtocol) -> UIViewController {
        let dbManager = MainDBManager()
        let interactor = MainInteractor(dbManager: dbManager)
        let view = MainView()
        let presenter = MainPresenter(view: view, interactor: interactor, router: router)
        view.presenter = presenter
        interactor.presenter = presenter
        
        return view
    }
    
    func detailModule(router: RouterProtocol, person: Person) -> UIViewController {
        let view = UIViewController()
        view.view.backgroundColor = .yellow
        print(person)
        return view
    }
}
