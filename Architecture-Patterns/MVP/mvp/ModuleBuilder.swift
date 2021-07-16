//
//  ModuleBuilder.swift
//  mvp
//
//  Created by Антон Тимонин on 25.08.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import UIKit

protocol ProtocolBuilder {
    static func createFirstModule() -> UIViewController
    static func createHomeModule() -> UIViewController
}

class ModuleBuilder: ProtocolBuilder {
    static func createFirstModule() -> UIViewController {
        let networkService = NetworkService()
        let view = FirstView()
        let presenter = FirstPresenter(view: view, networkService: networkService)
        view.presenter = presenter
        
        return view
    }
    
    static func createHomeModule() -> UIViewController {
        let person = Person(name: "Anton", text: "Hello, it is example text")
        let view = HomeView()
        let presenter = HomePresenter(view: view, person: person)
        view.presenter = presenter
        
        return view
    }
}
