import http from "k6/http";
import { check, sleep } from "k6";

export const options = {
    stages: [
        { duration: "60s", target: 1 }
    ]
}

export default function() {
    const apiUrl = `http://localhost/api/Teacher`;
    const response = http.get(apiUrl)
    check(response, {
        'response code was 200': (res) => res.status == 200
    });
}