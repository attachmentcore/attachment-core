
export function ObjectToFormData(object: any): FormData {
  var form_data = new FormData();

  for (var key in object) {
    console.log(typeof object)
    if (object instanceof FileList)
      for (var i = 0; i < object.length; i++)
        form_data.append(key, object[i])

    form_data.append(key, object[key]);
  }
  return form_data;
}
export function AddObjectToUrl(url: string, object: any): string {
  var urlObject = new URL(url.replace(/\/$/g, ''))
  Object.keys(object).forEach(key => {
    if (object[key])
      urlObject.searchParams.append(key, object[key])
  });
  return urlObject.toString();
}
function GetBaseUrl(): string {
  return "https://localhost:44327/";
}
export function GetUrl(url: string): string {
  let baseUrl = GetBaseUrl();
  baseUrl = baseUrl.replace(/\/$/g, '');
  let changedUrl = url.replace(/^\/+/g, '');
  return new String(baseUrl).concat("/", changedUrl);
}
export function FormatDate(isoDate: Date): string {
  return new Date(isoDate).toDateString();
}
export function FormatSize(bytes: number): string {
  var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
  if (bytes == 0) return '0 Byte';
  var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)).toString());
  return Math.round(bytes / Math.pow(1024, i)) + ' ' + sizes[i];
}

