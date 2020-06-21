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

    let ref depth = 1;

    iterate_tree_depth(&&main_boss_id_vec, &&main_vec, *depth);
    println!("{:?}", depth);
}

fn iterate_tree_depth(middle_vector: &Vec<i32>, people_vec: &Vec<i32>, mut depth: i32) {
    let mut all_length_is_null: bool = true;
    let a = middle_vector.len();

    for i in 0..a {
        let y_vec = people_vec
            .iter()
            .filter(|&&x| x == (middle_vector[i] as i32))
            .cloned()
            .collect::<Vec<i32>>();

        if y_vec.len() > 1 {
            all_length_is_null = false;
            iterate_tree_depth(&&y_vec, &&people_vec, depth);
        }
    }

    if !all_length_is_null {
        depth += 1;
    }
}
