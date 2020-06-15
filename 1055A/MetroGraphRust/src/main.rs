use std::io::{self, BufRead};

fn main() {

    let reader = io::stdin();

    let n_s_array: Vec<u32> =
    reader.lock()
          .lines().next().unwrap().unwrap()
          .split(' ').map(|s| s.trim())
          .filter(|s| !s.is_empty())
          .map(|s| s.parse().unwrap())
          .collect();

    let a_array: Vec<i32> =
    reader.lock()
          .lines().next().unwrap().unwrap()
          .split(' ').map(|s| s.trim())
          .filter(|s| !s.is_empty())
          .map(|s| s.parse().unwrap())
          .collect();

    let b_array: Vec<i32> =
          reader.lock()
                .lines().next().unwrap().unwrap()
                .split(' ').map(|s| s.trim())
                .filter(|s| !s.is_empty())
                .map(|s| s.parse().unwrap())
                .collect();

    let n = (n_s_array[0] as usize) - 1;
    let s = (n_s_array[1] as usize) - 1;

    if a_array[0] == 0 {
        println!("NO");
        return;
    }

    if s == n {
        if a_array[n] == 0 {
            println!("NO");
            return;
        }
        else {
            println!("YES");
            return;
        }
    }

    if a_array[s] == 0 && b_array[s] == 0 {
        println!("NO");
        return;
    }

    if a_array[s] != 0 && b_array[s] != 0 {
        println!("YES");
        return;
    }

    if a_array[s] == 0 {

        for i in s..(n + 1) {
            if a_array[i] == 1 && b_array[i] == 1 {
                println!("YES");
                return;
            }
        }

        println!("NO");
        return;
    }

    println!("YES");
}