//
//  Router.swift
//  VIPER
//
//  Created by Антон Тимонин on 01.04.2021.
//

import UIKit

protocol RouterProtocol {
    func initViewController()
    init(navigation: UINavigationController, assembly: AssemblyModulesProtocol)
}

class RouterModules: RouterProtocol {
    let navigation: UINavigationController!
    let assembly: AssemblyModulesProtocol!
    
    required init(navigation: UINavigationController, assembly: AssemblyModulesProtocol) {
        self.navigation = navigation
        self.assembly = assembly
    }
    
    func initViewController() {
        let module = assembly.mainModule()
        navigation.pushViewController(module, animated: true)
    }
}
