use std::io::{self, BufRead};

fn main() {

    let reader = io::stdin();

    let n_array: Vec<u32> =
    reader.lock()
          .lines().next().unwrap().unwrap()
          .split(' ').map(|s| s.trim())
          .filter(|s| !s.is_empty())
          .map(|s| s.parse().unwrap())
          .collect();

    let _f_array: Vec<i32> =
    reader.lock()
          .lines().next().unwrap().unwrap()
          .split(' ').map(|s| s.trim())
          .filter(|s| !s.is_empty())
          .map(|s| s.parse().unwrap())
          .collect();

    let _n: u32 =  n_array[0];
    let mut is_having_triangles: bool = false;
    let mut matrix = vec![vec![0; _n as usize]; _n as usize];

    for _i in 0.._n{
        matrix[_i as usize][(_f_array[_i as usize] - 1) as usize] = 1;
    }

    for _a in 0.._n {

        for _b in 0.._n {

            if matrix[_a as usize][_b as usize] != 1{
                continue;
            }

            for _c in 0.._n{
                if matrix[_b as usize][_c as usize] == 1 && matrix[_c as usize][_a as usize] == 1 {
                    is_having_triangles = true;
                    println!("YES");
                    return;
                }
            }
        }
    }

    println!("NO");
}