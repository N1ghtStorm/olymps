use std::io::{self, BufRead};

fn main() {
    let reader = io::stdin();
    let n: u32 = reader
        .lock()
        .lines()
        .next()
        .unwrap()
        .unwrap()
        .parse()
        .unwrap();

    let mut main_vec: Vec<i32> = vec![0; n as usize];
    let mut main_boss_id_vec: Vec<i32> = Vec::new();

    for i in 0..(n as usize) {
        let rel = reader
            .lock()
            .lines()
            .next()
            .unwrap()
            .unwrap()
            .parse()
            .unwrap();

        main_vec[i] = rel;
        if rel == -1 {
            main_boss_id_vec.push(i as i32)
        }
    }

    let mut depth = 1;

    //println!("{:?}", main_boss_id_vec);

    iterate_tree_depth(&&main_boss_id_vec, &&main_vec, &mut depth);
    println!("{:?}", depth);
}

fn iterate_tree_depth(boss_vector: &Vec<i32>, people_vec: &Vec<i32>, depth: &mut i32) {
    let mut all_length_is_null: bool = true;
    let a = boss_vector.len();

    for i in 0..a {
        let worker_vec = people_vec
            .iter()
            .filter(|&&x| x == boss_vector.iter().position(|&s| s == i))
            .cloned()
            .collect::<Vec<i32>>();

        println!("{:?}", boss_vector[i]);

        if worker_vec.len() > 0 {
            all_length_is_null = false;
            iterate_tree_depth(&&worker_vec, &&people_vec, depth);
        }
    }

    if !all_length_is_null {
        *depth = *depth + 1;
    }
}
