#include <iostream>
using namespace std;

class Singleton {
private:
    Singleton() {};
    Singleton(Singleton*);
    Singleton(const Singleton&);
    Singleton& operator=(Singleton&);
    
    static Singleton *instance;
    
public:
    static Singleton* get_instance() {
        if (instance == nullptr) {
            instance =  new Singleton;
        }
        return instance;
    }
};

int main(int argc, const char * argv[]) {
    cout << "Hello, World!\n";
    return 0;
}
