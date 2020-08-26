import UIKit

class HomeView: UIViewController, HomePresenterInput {
    public var presenter: HomePresenterOutput?
    
    var greetingLabel: UILabel = {
        let label = UILabel(frame: CGRect(x: 40, y: 150, width: 300, height: 100))
        label.numberOfLines = 0
        label.text = "Tappp the button"
        return label
    }()
    
    var tapButton: UIButton = {
        let button = UIButton(frame: CGRect(x: 40, y: 350, width: 100, height: 50))
        button.titleLabel?.text = "Tap"
        button.titleLabel?.textColor = .black
        button.backgroundColor = .green
        return button
    }()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        setupLayout()
        setupView()
    }
    
    fileprivate func setupLayout() {
        self.view.backgroundColor = .white
    }
    
    fileprivate func setupView() {
        self.view.addSubview(greetingLabel)
        self.view.addSubview(tapButton)
        tapButton.addTarget(self, action: #selector(setButtonTapped(_:)), for: .touchUpInside)
    }
    
    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(animated)
    }
    
    func setGreeting(greeting: String) {
        greetingLabel.text = greeting
    }
    
    @objc func setButtonTapped(_ sender: UIButton) {
        presenter?.setGreeting()
    }
}

