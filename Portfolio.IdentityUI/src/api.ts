import ky from 'ky';

const api = ky.create({
  prefixUrl: `${window.location.origin}/id`
});

export default api;
