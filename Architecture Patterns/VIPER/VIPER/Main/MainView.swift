import UIKit

class MainView: UIViewController, MainViewInputProtocol {
    
    var presenter: MainPresenterViewEventHandler!
    
    let personLabel: UILabel = {
        let lbl = UILabel()
        lbl.backgroundColor = .blue
        lbl.layer.cornerRadius = 8
        lbl.textColor = .white
        lbl.textAlignment = .center
        return lbl
    }()
    
    let confirmButton: UIButton = {
        let btn = UIButton()
        btn.setTitle("Confirm", for: .normal)
        btn.setTitleColor(#colorLiteral(red: 1, green: 0.661038518, blue: 0.8165349364, alpha: 1), for: .highlighted)
        btn.backgroundColor = .systemPink
        btn.layer.cornerRadius = 8
        return btn
    }()
    
    let detailButton: UIButton = {
        let btn = UIButton()
        btn.setTitle("Detail", for: .normal)
        btn.setTitleColor(#colorLiteral(red: 0.3077901304, green: 0.5086878538, blue: 0.1806027889, alpha: 1), for: .highlighted)
        btn.backgroundColor = #colorLiteral(red: 0.4666666687, green: 0.7647058964, blue: 0.2666666806, alpha: 1)
        btn.layer.cornerRadius = 8
        return btn
    }()

    override func viewDidLoad() {
        super.viewDidLoad()
        
        self.view.backgroundColor = .white
        confirmButton.addTarget(self, action: #selector(confirmButtonTapped(sender:)), for: .touchUpInside)
        detailButton.addTarget(self, action: #selector(detailButtonTapped(sender:)), for: .touchUpInside)
        
        setupView()
    }
    
    private func setupView() {
        view.addSubview(personLabel)
        view.addSubview(confirmButton)
        view.addSubview(detailButton)
    }
    
    override func viewDidLayoutSubviews() {
        let screen = UIScreen.main.bounds.size
        
        personLabel.frame = CGRect(x: 0, y: 0, width: screen.width - 20, height: 50)
        personLabel.center.y = view.center.y / 2
        personLabel.center.x = view.center.x
        
        confirmButton.frame = CGRect(x: 0, y: 0, width: screen.width - 20, height: 50)
        confirmButton.center.y = view.center.y / 1.5
        confirmButton.center.x = view.center.x
        
        detailButton.frame = CGRect(x: 0, y: 0, width: screen.width - 20, height: 50)
        detailButton.center.y = view.center.y / 1.2
        detailButton.center.x = view.center.x
    }
    
    @objc
    func confirmButtonTapped(sender: UIButton) {
        presenter.didTapConfirmButton()
    }
    
    @objc
    func detailButtonTapped(sender: UIButton) {
        presenter.didTapDetailButton()
    }
    
    func setPerson(person: Person) {
        personLabel.text = "\(person.firstName) \(person.lastName) \(person.age)"
    }
}

