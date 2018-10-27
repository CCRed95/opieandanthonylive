export const flattenArray = <T>(xs: T[][]): T[] =>
  [].concat.apply([], xs);

export const validEmail = (email: string): boolean => {
  const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  return re.test(email);
}

export const decodeJwt = (token: string): any => {
  const base64Url = token.split('.')[1];
  const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  return JSON.parse(window.atob(base64));
}

export const min = (x: number, y: number) =>
  x < y ? x : y;

export const max = (x: number, y: number) =>
  x > y ? x : y;

export const clamp = (lowerBound: number, x: number, upperBound: number) =>
  min(max(lowerBound, x), upperBound)

export const drag = (
  onGrab: () => void,
  onMove: (ev: MouseEvent) => void,
  onDrop: (ev: MouseEvent) => void
) => {
  const mouseUp = (ev: MouseEvent) => {
    document.removeEventListener('mousemove', onMove);
    document.removeEventListener('mouseup', mouseUp);
    onDrop(ev);
  }

  document.addEventListener('mousemove', onMove);
  document.addEventListener('mouseup', mouseUp);

  onGrab();
};
