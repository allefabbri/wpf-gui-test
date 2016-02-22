#include <iostream>
#include <fstream>

using namespace std;

int main(int argc, char ** argv){
  double x=0.0;
  if (argc > 1) {
    x = atof(argv[1]);
  }
  ofstream ofi("product.txt");
  ofi << 2 * x << endl;
  ofi.close();
  return 0;
}